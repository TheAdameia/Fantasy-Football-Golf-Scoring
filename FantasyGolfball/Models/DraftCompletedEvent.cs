namespace FantasyGolfball.Models;

public class DraftCompletedEvent
{
    public int LeagueId { get; set; }
    public DraftCompletedEvent(int leagueId)
    {
        LeagueId = leagueId;
    }
}