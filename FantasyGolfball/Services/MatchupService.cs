using FantasyGolfball.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Models;

namespace FantasyGolfball.Services;

public interface IMatchupService
{
    Task GenerateMatchups(int leagueId, int totalWeeks, int gamesPerPlayer);
}

public class MatchupService : IMatchupService
{
    private readonly IDbContextFactory<FantasyGolfballDbContext> _dbContextFactory;

    public MatchupService(IDbContextFactory<FantasyGolfballDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task GenerateMatchups(int leagueId, int totalWeeks, int gamesPerPlayer)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var users = await context.LeagueUsers
            .Where(lu => lu.LeagueId == leagueId)
            .Select(lu => lu.UserProfileId)
            .ToListAsync();

        if (users.Count < 2) return; // this shouldn't happen because this should only trigger when a draft is completed

        var matchups = new List<Matchup>();

        var baseSchedule = GenerateRoundRobin(users);

        int weekId = 1;
        for (int cycle = 0; cycle < gamesPerPlayer; cycle++)
        {
            foreach (var round in baseSchedule)
            {
                var matchup = new Matchup
                {
                    LeagueId = leagueId,
                    WeekId = weekId,
                    MatchupUsers = round.Select(userId => new MatchupUser {UserProfileId = userId}).ToList() 
                    //this stuff in the brackets is some real black magic
                };

                matchups.Add(matchup);
                weekId = (weekId % totalWeeks) + 1;
            }
        }

        context.Matchups.AddRange(matchups); //AddRange is a new one
        await context.SaveChangesAsync();
    }

    private List<List<int>> GenerateRoundRobin(List<int> users) // Yo dawg I herd u liek lists
    {
        int numUsers = users.Count();
        if (numUsers % 2 != 0) users.Add(-1); //bye if odd number of users

        int numRounds = users.Count - 1;
        var schedule = new List<List<int>>();

        for (int round = 0; round < numRounds; round++)
        {
            var roundMatches = new List<int>();
            for (int i = 0; i < numUsers / 2; i++)
            {
                int userA = users[i];
                int userB = users[numUsers - 1 - i]; // what.gif

                if (userA != -1 && userB != -1) //ignores byes
                { // this bracket was missing, why
                    roundMatches.AddRange(new[] {userA, userB});
                }
            }

            schedule.Add(roundMatches);
            users.Insert(1, users[^1]); // rotates players
            users.RemoveAt(users.Count - 1);
        }

        return schedule;
    }
}