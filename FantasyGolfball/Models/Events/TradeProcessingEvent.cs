namespace FantasyGolfball.Models.Events;

public class TradeProcessingEvent
{
    public int LeagueId { get; }
    public int NewWeek { get; }

    public TradeProcessingEvent(int leagueId, int newWeek)
    {
        LeagueId = leagueId;
        NewWeek = newWeek;
    }
}