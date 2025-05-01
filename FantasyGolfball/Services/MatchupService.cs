using FantasyGolfball.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Models;
using FantasyGolfball.Models.Events;

namespace FantasyGolfball.Services;

public interface IMatchupService
{
    Task GenerateMatchups(int leagueId, int totalWeeks, int gamesPerPlayer);
    Task HandleDraftCompleted(int leagueId);
}

public class MatchupService : IMatchupService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IEventBus _eventBus;

    public MatchupService(IServiceScopeFactory scopeFactory, IEventBus eventBus)
    {
        _scopeFactory = scopeFactory;
        _eventBus = eventBus;
        Console.WriteLine("MatchupService initiated");
        eventBus.Subscribe<int>(HandleDraftCompleted);
    }

    private FantasyGolfballDbContext GetDbContext()
    {
        var scope = _scopeFactory.CreateScope();
        return scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();
    }

    public async Task HandleDraftCompleted(int leagueId)
    {
        Console.WriteLine($"Attempting to generate matchups for {leagueId}");

        int totalWeeks = 4; // I need to change League to have these properties... eventually
        int gamesPerPlayer = 4;
        try
        {
            await GenerateMatchups(leagueId, totalWeeks, gamesPerPlayer);
        }
        catch (Exception ex)
        {
            throw new Exception($"Something went wrong in HandleDraftCompleted, ex: {ex}");
        }
        
    }
    public async Task GenerateMatchups(int leagueId, int totalWeeks, int gamesPerPlayer)
    {
        using var context = GetDbContext();

        var users = await context.LeagueUsers
            .Where(lu => lu.LeagueId == leagueId)
            .Select(lu => lu.UserProfileId)
            .ToListAsync();

        if (users.Count < 2) return; // this shouldn't happen because this should only trigger when a draft is completed. I wish I could have this return some kind of error

        var matchups = new List<Matchup>();

        var baseSchedule = GenerateRoundRobin(users);

        int weekId = 1;
        for (int cycle = 0; cycle < gamesPerPlayer; cycle++)
        {
            foreach (var round in baseSchedule)
            {
                foreach (var (userA, userB) in round)
                {
                    var matchup = new Matchup
                    {
                        LeagueId = leagueId,
                        WeekId = weekId,
                        MatchupUsers = new List<MatchupUser>
                        {
                            new MatchupUser { UserProfileId = userA },
                            new MatchupUser { UserProfileId = userB }
                        }
                    };
                    matchups.Add(matchup);
                }
                weekId = (weekId % totalWeeks) + 1;
            }
        }

        context.Matchups.AddRange(matchups); //AddRange is a new one
        await context.SaveChangesAsync();
    }

    private List<List<(int, int)>> GenerateRoundRobin(List<int> users)
    {
        int numUsers = users.Count;
        if (numUsers % 2 != 0) users.Add(-1); // add bye

        int numRounds = users.Count - 1;
        var schedule = new List<List<(int, int)>>();

        for (int round = 0; round < numRounds; round++)
        {
            var roundMatches = new List<(int, int)>();
            for (int i = 0; i < numUsers / 2; i++)
            {
                int userA = users[i];
                int userB = users[numUsers - 1 - i];

                if (userA != -1 && userB != -1)
                {
                    roundMatches.Add((userA, userB));
                }
            }

            schedule.Add(roundMatches);
            users.Insert(1, users[^1]);
            users.RemoveAt(users.Count - 1);
        }

        return schedule;
    }
}