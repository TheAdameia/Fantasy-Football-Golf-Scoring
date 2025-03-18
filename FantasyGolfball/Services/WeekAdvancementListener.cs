namespace FantasyGolfball.Services;

using FantasyGolfball.Data;
using FantasyGolfball.Models.Events;
using Microsoft.EntityFrameworkCore;

public class WeekAdvancementListenerService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public WeekAdvancementListenerService(IEventBus eventBus, IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;

        eventBus.Subscribe<WeekAdvancedEvent>(HandleWeekAdvanced);
    }

    private async Task HandleWeekAdvanced(WeekAdvancedEvent eventData)
    {
        Console.WriteLine($"Handling WeekAdvancedEvent for Season {eventData.SeasonId}, New Week: {eventData.NewWeek}");

        using var scope = _scopeFactory.CreateScope(); // creates a new scope to ensure fresh db
        var dbContext = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();

        var season = await dbContext.Seasons.FirstOrDefaultAsync(s => s.SeasonId == eventData.SeasonId);

        if (season == null)
        {
            throw new Exception($"Season {eventData.SeasonId} not found");
        }

        Console.WriteLine($"Performing updates for Season {season.SeasonYear} now in Week {eventData.NewWeek}");

        int previousWeek = eventData.NewWeek - 1;
        if (previousWeek <= 0)
        {
            throw new Exception($"previousWeek {previousWeek} error for season {eventData.SeasonId}");
        }

        var leagues = await dbContext.Leagues
            .Where(l => l.SeasonId == season.SeasonId)
            .ToListAsync();

        foreach (var league in leagues)
        {
            var matchups = await dbContext.Matchups
                .Where(m => m.LeagueId == league.LeagueId)
                .Include(m => m.MatchupUsers)
                .ThenInclude(mu => mu.userProfile)
                .ToListAsync();

            foreach (var matchup in matchups)
            {
                if (matchup.MatchupUsers.Count != 2)
                {
                    throw new Exception($"matchup {matchup.MatchupId} containers a non-2 number of MU");
                }

                var scores = new Dictionary<int, float>(); // key: userprofileid, value: sum score

                foreach (var matchupUser in matchup.MatchupUsers)
                {
                    var roster = await dbContext.Rosters
                        .Where(r => r.UserId == matchupUser.UserProfileId && r.LeagueId == league.LeagueId)
                        .Include(r => r.RosterPlayers)
                        .FirstOrDefaultAsync();
                    
                    if (roster == null)
                    {
                        throw new Exception($"user {matchupUser.UserProfileId} in league {league.LeagueId} did not return a roster");
                    }
                    
                    float totalScore = await dbContext.Scorings
                        .Where(s => s.SeasonYear == season.SeasonYear &&
                                    s.SeasonWeek ==  previousWeek &&
                                    roster.RosterPlayers
                                        .Where(rp => rp.RosterPosition != "bench")
                                        .Select(rp => rp.PlayerId)
                                        .Contains(s.PlayerId))
                        .SumAsync(s => s.Points);
                    
                    scores[matchupUser.UserProfileId] = totalScore;
                }

                if (scores.Count == 2)
                {
                    var winner = scores.OrderByDescending(kv => kv.Value).First();
                    matchup.WinnerId = winner.Key;
                }
            }
        }
    await dbContext.SaveChangesAsync();
    Console.WriteLine("Completed Week Advancement matchup processing.");
    }
}