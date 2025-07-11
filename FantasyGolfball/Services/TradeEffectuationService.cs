using FantasyGolfball.Data;
using FantasyGolfball.Models.Events;
using Microsoft.EntityFrameworkCore;

namespace FantasyGolfball.Services;

public class TradeEffectuationService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IEventBus _eventBus;

    public TradeEffectuationService(IEventBus eventBus, IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        _eventBus = eventBus;

        eventBus.Subscribe<TradeProcessingEvent>(HandleTradeChecks);
    }

    private async Task HandleTradeChecks(TradeProcessingEvent eventData)
    {
        using var scope = _scopeFactory.CreateScope(); // creates a new scope to ensure fresh db
        var dbContext = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();

        // good test case for explain analyze if the database ever gets big. Few different ways this could be done.
        var league = await dbContext.Leagues
            .Include(l => l.LeagueUsers)
                .ThenInclude(lu => lu.Roster)
                    .ThenInclude(r => r.RosterPlayers)
            .FirstOrDefaultAsync(l => l.LeagueId == eventData.LeagueId);

        if (league == null)
        {
            throw new Exception($"League {eventData.LeagueId} not found in TES");
        }

        var trades = await dbContext.Trades
            .Include(t => t.TradePlayers)
            .Where(t => t.LeagueId == eventData.LeagueId)
            .Where(t => t.TradeComplete == false)
            .Where(t => t.WeekActivation == eventData.NewWeek)
            .Where(t => t.FirstPartyAcceptance == true && t.SecondPartyAcceptance == true)
            .ToListAsync();

        var rolloverTrades = await dbContext.Trades
            .Where(t => t.LeagueId == eventData.LeagueId)
            .Where(t => t.TradeComplete == false)
            .Where(t => t.WeekActivation <= eventData.NewWeek)
            .Where(t => t.FirstPartyAcceptance == true && t.SecondPartyAcceptance == false)
            .ToListAsync();

        if (!trades.Any() && !rolloverTrades.Any())
        {
            Console.WriteLine($"No trades to process for League {eventData.LeagueId}, week {eventData.NewWeek}");
            return;
        }

        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            if (trades.Any())
            {
                foreach (var trade in trades)
                {
                    Console.WriteLine($"Processing Trade {trade.TradeId}");
                    var firstLeagueUser = league.LeagueUsers.SingleOrDefault(lu => lu.RosterId == trade.FirstPartyRosterId);
                    var secondLeagueUser = league.LeagueUsers.SingleOrDefault(lu => lu.RosterId == trade.SecondPartyRosterId);

                    if (firstLeagueUser == null)
                    {
                        Console.WriteLine($"LeagueUser not found for RosterId {trade.FirstPartyRosterId} in TES");
                        continue;
                    }
                    if (secondLeagueUser == null)
                    {
                        Console.WriteLine($"LeagueUser not found for RosterId {trade.SecondPartyRosterId} in TES");
                        continue;
                    }

                    foreach (var tp in trade.TradePlayers)
                    {
                        var rosterPlayer = league.LeagueUsers
                            .Where(lu => lu.LeagueId == trade.LeagueId)
                            .SelectMany(lu => lu.Roster.RosterPlayers)
                            .FirstOrDefault(rp => rp.PlayerId == tp.PlayerId && rp.RosterId == tp.GivingRosterId);

                        if (rosterPlayer == null)
                        {
                            Console.WriteLine($"No matching RosterPlayer found for PlayerId {tp.PlayerId} in League {trade.LeagueId} in TES.");
                            continue;
                        }

                        var alreadyExists = await dbContext.RosterPlayers
                            .AnyAsync(rp => rp.RosterId == tp.ReceivingRosterId && rp.PlayerId == tp.PlayerId);

                        if (!alreadyExists)
                        {
                            rosterPlayer.RosterId = tp.ReceivingRosterId;
                            rosterPlayer.RosterPosition = "bench";
                            Console.WriteLine($"Player {rosterPlayer.PlayerId} moved to Roster {rosterPlayer.RosterId}, {tp.ReceivingRosterId}");
                        }
                        else
                        {
                            Console.WriteLine($"Player {tp.PlayerId} already exists in receiving Roster {tp.ReceivingRosterId} in TES.");
                        }
                    }
                    trade.TradeComplete = true;
                }
            }

            if (rolloverTrades.Any())
            {
                foreach (var trade in rolloverTrades)
                {
                    trade.WeekActivation = eventData.NewWeek + 1;
                }
            }
            

            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            Console.WriteLine($"Trades in League {league.LeagueId} for new week {eventData.NewWeek} committed.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Console.WriteLine($"Transaction (TES, League {league.LeagueId}) rolled back due to error: {ex.Message}");
        }

        
    }
}