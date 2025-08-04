namespace FantasyGolfball.Models;

// this refers to the actual football teams and not a user's roster.

public class Team
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public string TeamCity { get; set; }
    public string? Abbreviation { get; set; }
    public int? ByeWeek { get; set; }
}