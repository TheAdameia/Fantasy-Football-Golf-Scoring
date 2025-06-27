namespace FantasyGolfball.Models.Events
{
    public class ScoreRevealEvent
    {
        public int LeagueId { get; }
        public int WeekNumber { get; }

        public ScoreRevealEvent(int leagueId, int weekNumber)
        {
            LeagueId = leagueId;
            WeekNumber = weekNumber;
        }
    }
}
