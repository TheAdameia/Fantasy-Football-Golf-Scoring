namespace FantasyGolfball.Models;

// this refers to the actual football teams and not a user's roster.

public class Team
{
    public int TeamId { get; set; }
    public required string TeamName { get; set; }
    public required string TeamCity { get; set; }
    public required string Abbreviation { get; set; }
    public int? ByeWeek { get; set; }
    public int SeasonId { get; set; }
}