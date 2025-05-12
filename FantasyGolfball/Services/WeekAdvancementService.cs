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
            var leagues = await dbContext.Leagues
                .Where(l => !l.IsLeagueFinished)
                .ToListAsync(stoppingToken);

            foreach (var league in leagues)
            {
                int? latestWeek = league.CurrentWeek;

                // if (latestWeek >= 5)
                // {
                //     continue; // skips this iteration and continues the loop. Move to WALS now that it's league? Obsolete
                // }

                if (latestWeek.HasValue && league.LastRecordedWeek != latestWeek)
                {
                    league.LastRecordedWeek = latestWeek; // updates stored value
                    await dbContext.SaveChangesAsync(stoppingToken);

                    await _eventBus.Publish(new WeekAdvancedEvent(league.LeagueId, latestWeek.Value)); // triggers event
                }
            }
        }
    }
}
