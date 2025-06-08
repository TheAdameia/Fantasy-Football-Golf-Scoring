namespace FantasyGolfball.Models;

public class Season
{
    public int SeasonId { get; set; }
    public int SeasonYear { get; set; }
    public int SeasonWeeks { get; set; } //sets how many weeks are in the season - this varies historically in the NFL
}