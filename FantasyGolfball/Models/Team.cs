namespace FantasyGolfball.Models;

// this refers to the actual football teams and not a user's roster.

public class Team
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public string TeamCity { get; set; }
    public int ByeWeek { get; set; }
    public List<ActivePeriod> ActivePeriods { get; set; } = new();

    public bool PlayerMovePossible
    {
        get
        {
            DateTime now = DateTime.Now;
            return ActivePeriods.Any(period => now >= period.Start && now <= period.End);
        }
    }

}