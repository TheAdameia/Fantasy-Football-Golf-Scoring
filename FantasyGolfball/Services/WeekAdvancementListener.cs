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

        // TODO: Implement logic that runs when a week advances
        Console.WriteLine($"Performing updates for Season {season.SeasonYear} now in Week {eventData.NewWeek}");

        // await dbContext.SaveChangesAsync();

    }
}