namespace FantasyGolfball.Models.Events;

public class WeekAdvancedEvent
{
    public int SeasonId { get; }
    public int NewWeek { get; }

    public WeekAdvancedEvent(int seasonId, int newWeek)
    {
        SeasonId = seasonId;
        NewWeek = newWeek;
    }
}