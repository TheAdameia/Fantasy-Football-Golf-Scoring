using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.Events;
using FantasyGolfball.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

public class WeekAdvancementListenerServiceTests
{
    [Fact]
    public async Task HandleWeekAdvanced_UpdatesMatchupsAndScores_WhenEventIsReceived()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<FantasyGolfballDbContext>()
            .UseInMemoryDatabase("TestDb_WeekAdvancementListener")
            .Options;

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>())
            .Build();

        using var context = new FantasyGolfballDbContext(options, config);
        
        var season = new Season { SeasonId = 1, SeasonYear = 2025 };
        context.Seasons.Add(season);
        
        var league = new League { LeagueId = 1, SeasonId = 1, LeagueName = "Tests" };
        context.Leagues.Add(league);
        
        var user1 = new UserProfile { Id = 1, IdentityUserId = "admin" };
        var user2 = new UserProfile { Id = 2, IdentityUserId = "bob" };
        context.UserProfiles.AddRange(user1, user2);

        var matchup = new Matchup
        {
            MatchupId = 1,
            LeagueId = 1,
            MatchupUsers = new List<MatchupUser>
            {
                new MatchupUser { MatchupId = 1, UserProfileId = 1 },
                new MatchupUser { MatchupId = 1, UserProfileId = 2 }
            }
        };
        context.Matchups.Add(matchup);

        var roster1 = new Roster { RosterId = 1, UserId = 1, LeagueId = 1 };
        var roster2 = new Roster { RosterId = 2, UserId = 2, LeagueId = 1 };
        context.Rosters.AddRange(roster1, roster2);

        var players = new List<Player>
        {
            new Player { PlayerId = 1, PlayerFirstName = "A", PlayerLastName = "B" },
            new Player { PlayerId = 2, PlayerFirstName = "C", PlayerLastName = "D" },
            new Player { PlayerId = 3, PlayerFirstName = "D", PlayerLastName = "E" },
            new Player { PlayerId = 4, PlayerFirstName = "F", PlayerLastName = "G" },
            new Player { PlayerId = 5, PlayerFirstName = "H", PlayerLastName = "I" },
            new Player { PlayerId = 6, PlayerFirstName = "J", PlayerLastName = "K" },
            new Player { PlayerId = 7, PlayerFirstName = "L", PlayerLastName = "M" },
            new Player { PlayerId = 8, PlayerFirstName = "N", PlayerLastName = "O" }
        };
        context.Players.AddRange(players);

        var rosterPlayers = new List<RosterPlayer>
        {
            new RosterPlayer { RosterId = 1, PlayerId = 1, RosterPosition = "QB1" },
            new RosterPlayer { RosterId = 1, PlayerId = 2, RosterPosition = "WR1" },
            new RosterPlayer { RosterId = 1, PlayerId = 3, RosterPosition = "RB1" },
            new RosterPlayer { RosterId = 1, PlayerId = 4, RosterPosition = "DEF" },
            new RosterPlayer { RosterId = 2, PlayerId = 5, RosterPosition = "K" },
            new RosterPlayer { RosterId = 2, PlayerId = 6, RosterPosition = "WR2" },
            new RosterPlayer { RosterId = 2, PlayerId = 7, RosterPosition = "RB2" },
            new RosterPlayer { RosterId = 2, PlayerId = 8, RosterPosition = "FLEX" }
        };
        context.RosterPlayers.AddRange(rosterPlayers);

        var scorings = new List<Scoring>
        {
            new Scoring { PlayerId = 1, SeasonYear = 2025, SeasonWeek = 1, Points = 10 },
            new Scoring { PlayerId = 2, SeasonYear = 2025, SeasonWeek = 1, Points = 5 },
            new Scoring { PlayerId = 3, SeasonYear = 2025, SeasonWeek = 1, Points = 8 },
            new Scoring { PlayerId = 4, SeasonYear = 2025, SeasonWeek = 1, Points = 7 },
            new Scoring { PlayerId = 5, SeasonYear = 2025, SeasonWeek = 1, Points = 12 },
            new Scoring { PlayerId = 6, SeasonYear = 2025, SeasonWeek = 1, Points = 6 },
            new Scoring { PlayerId = 7, SeasonYear = 2025, SeasonWeek = 1, Points = 9 },
            new Scoring { PlayerId = 8, SeasonYear = 2025, SeasonWeek = 1, Points = 11 }
        };
        context.Scorings.AddRange(scorings);

        await context.SaveChangesAsync();

        var scopeFactoryMock = new Mock<IServiceScopeFactory>();
        var scopeMock = new Mock<IServiceScope>();
        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock.Setup(x => x.GetService(typeof(FantasyGolfballDbContext))).Returns(context);
        scopeMock.Setup(x => x.ServiceProvider).Returns(serviceProviderMock.Object);
        scopeFactoryMock.Setup(x => x.CreateScope()).Returns(scopeMock.Object);

        var eventBusMock = new Mock<IEventBus>();
        var service = new WeekAdvancementListenerService(eventBusMock.Object, scopeFactoryMock.Object);

        var weekAdvancedEvent = new WeekAdvancedEvent(1, 2);

        // Act
        var task = (Task)service.GetType()
            .GetMethod("HandleWeekAdvanced", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .Invoke(service, new object[] { weekAdvancedEvent });

        await task;

        // Assert
        var updatedMatchup = await context.Matchups.FindAsync(matchup.MatchupId);
        Assert.NotNull(updatedMatchup);
        Assert.NotNull(updatedMatchup.WinnerId);
        Assert.Equal(1, updatedMatchup.WinnerId); // Ensure the correct winner is assigned
    }
}
