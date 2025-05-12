namespace FantasyGolfball.Models.DTOs;

// this refers to the actual football teams and not a user's roster.

public class TeamDTO
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public string TeamCity { get; set; }
    public int? ByeWeek { get; set; }
    public List<ActivePeriodDTO> ActivePeriods { get; set; } = new();

    public bool PlayerMovePossible
    {
        get
        {
            DateTime now = DateTime.UtcNow;
            return ActivePeriods.Any(period => now >= period.Start && now <= period.End);
        }
    }

}