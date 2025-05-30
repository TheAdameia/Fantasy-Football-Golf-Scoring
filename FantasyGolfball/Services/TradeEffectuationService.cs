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

        eventBus.Subscribe<TradeProcessingEvent>(HandleTrackChecks);
    }

    private async Task HandleTrackChecks(TradeProcessingEvent eventData)
    {
        using var scope = _scopeFactory.CreateScope(); // creates a new scope to ensure fresh db
        var dbContext = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();

        var league = await dbContext.Leagues.FirstOrDefaultAsync(l => l.LeagueId == eventData.LeagueId);

        if (league == null)
        {
            throw new Exception($"League {eventData.LeagueId} not found in TES");
        }

        var trades = await dbContext.Trades
            .Where(t => t.LeagueId == eventData.LeagueId)
            .Where(t => t.TradeComplete == false)
            .Where(t => t.WeekActivation == eventData.NewWeek)
            .Where(t => t.FirstPartyAcceptance == true && t.SecondPartyAcceptance == true)
            .ToListAsync();

        if (trades == null)
        {
            return;
        }

        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            foreach (var trade in trades)
            {
                var FirstLeagueUser = league.LeagueUsers.SingleOrDefault(lu => lu.RosterId == trade.FirstPartyRosterId);
                var SecondLeagueUser = league.LeagueUsers.SingleOrDefault(lu => lu.RosterId == trade.SecondPartyRosterId);

                if (FirstLeagueUser == null)
                {
                    Console.WriteLine($"LeagueUser not found for RosterId {trade.FirstPartyRosterId} in TES");
                    continue;
                }
                if (SecondLeagueUser == null)
                {
                    Console.WriteLine($"LeagueUser not found for RosterId {trade.SecondPartyRosterId} in TES");
                    continue;
                }

                foreach (var tp in trade.TradePlayers)
                {
                    var rosterPlayer = league.LeagueUsers
                        .Where(lu => lu.LeagueId == trade.LeagueId)
                        .SelectMany(lu => lu.Roster.RosterPlayers)
                        .FirstOrDefault(rp => rp.PlayerId == tp.PlayerId);

                    if (rosterPlayer == null)
                    {
                        Console.WriteLine($"No matching RosterPlayer found for PlayerId {tp.PlayerId} in League {trade.LeagueId} in TES.");
                        return;
                    }

                    var alreadyExists = await dbContext.RosterPlayers
                        .AnyAsync(rp => rp.RosterId == tp.ReceivingRosterId && rp.PlayerId == tp.PlayerId);

                    if (!alreadyExists)
                    {
                        rosterPlayer.RosterId = tp.ReceivingRosterId;
                        rosterPlayer.RosterPosition = "bench";
                    }
                    else
                    {
                        Console.WriteLine($"Player {tp.PlayerId} already exists in receiving Roster {tp.ReceivingRosterId} in TES.");
                    }

                }

                trade.TradeComplete = true;
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


// listen for ?? 
// have WALS fire an event for a League when it finishes, I guess. Safest way to avoid screwing with score/MUSP calculations.
// get trades where new week == WeekActivation AND FirstPartyAcceptance AND SecondPartyAcceptance
// get each roster
// find rps that go A => B, change rosterId
// find rps that go B => A, change rosterId
// mark the trade as completed? delete the trade? probably not delete
// save changes