using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using FantasyGolfball.Models.Events;

public class WeekAdvancementServiceTests
{
    [Fact]
    public async Task WeekAdvancementService_AdvancesWeek_WhenCurrentWeekChanges()
    {
        // arrange
        var options = new DbContextOptionsBuilder<FantasyGolfballDbContext>()
            .UseInMemoryDatabase("TestDb")  // in-memory db
            .Options;

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "AdminPassword", "TestPassword" }
            })
            .Build();

        using var context = new FantasyGolfballDbContext(options, config);

        var season = new Season
        {
            SeasonStartDate = new DateTime(2025, 3, 1),
            RealSeason = true,
            LastRecordedWeek = 2
        };

        context.Seasons.Add(season);
        await context.SaveChangesAsync();  // saves to in-memory db

        var scopeFactoryMock = new Mock<IServiceScopeFactory>();
        var eventBusMock = new Mock<IEventBus>();

        // mocks service scope for the sake of the db
        var scopeMock = new Mock<IServiceScope>();

        // I don't have a great understanding of this
        scopeMock.Setup(x => x.ServiceProvider.GetService(typeof(FantasyGolfballDbContext)))
            .Returns(context);
        scopeFactoryMock.Setup(x => x.CreateScope()).Returns(scopeMock.Object);

        // instantiates service
        var service = new WeekAdvancementService(scopeFactoryMock.Object, eventBusMock.Object);

        // act
        await service.PerformWeekAdvancement(CancellationToken.None);  // manually triggers week advancement

        // assert (verifies)
        var updatedSeason = await context.Seasons.FindAsync(season.SeasonId);
        Assert.NotNull(updatedSeason);
        Assert.NotEqual(2, updatedSeason.LastRecordedWeek);
    }
}
