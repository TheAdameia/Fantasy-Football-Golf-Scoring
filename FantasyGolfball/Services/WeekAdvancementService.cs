namespace FantasyGolfball.Services;
using FantasyGolfball.Data;
using FantasyGolfball.Models.Events;
using Microsoft.EntityFrameworkCore;


public class WeekAdvancementService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IEventBus _eventBus;

    public WeekAdvancementService(IServiceScopeFactory scopeFactory, IEventBus eventBus)
    {
        _scopeFactory = scopeFactory;
        _eventBus = eventBus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await PerformWeekAdvancement(stoppingToken);
            await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken); // runs every 15 minutes
        }
    }

    // Extracted method for testing purposes
    public async Task PerformWeekAdvancement(CancellationToken stoppingToken)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();
            var seasons = await dbContext.Seasons.ToListAsync(stoppingToken);

            foreach (var season in seasons)
            {
                int? latestWeek = season.CurrentWeek;

                if (latestWeek >= 5)
                {
                    continue; // skips this iteration and continues the loop
                }

                if (latestWeek.HasValue && season.LastRecordedWeek != latestWeek)
                {
                    season.LastRecordedWeek = latestWeek; // updates stored value
                    await dbContext.SaveChangesAsync(stoppingToken);

                    await _eventBus.Publish(new WeekAdvancedEvent(season.SeasonId, latestWeek.Value)); // triggers event
                }
            }
        }
    }
}
