namespace FantasyGolfball.Models.Events;

public class WeekAdvancedEvent
{
    public int LeagueId { get; }
    public int NewWeek { get; }

    public WeekAdvancedEvent(int leagueId, int newWeek)
    {
        LeagueId = leagueId;
        NewWeek = newWeek;
    }
}