namespace FantasyGolfball.Models.DTOs;

// this refers to the actual football teams and not a user's roster.

public class TeamDTO
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public string TeamCity { get; set; }
    public int? ByeWeek { get; set; }
    public string Abbreviation { get; set; }
}