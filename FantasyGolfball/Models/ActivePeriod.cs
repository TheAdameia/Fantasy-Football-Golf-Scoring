namespace FantasyGolfball.Models;

public class ActivePeriod
{
    public int ActivePeriodId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int TeamId { get; set; } 
    public Team Team { get; set; } 
}
