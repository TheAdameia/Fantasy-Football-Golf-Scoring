using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Player
{
    public int PlayerId { get; set; }
    public string PlayerFirstName { get; set;}
    public string PlayerLastName { get; set; }
    public int PositionId { get; set; }
    public int XRank { get; set; }
    public double CurrentWeekPoints { get; set; }
    public double LastWeekPoints { get; set; }
    public double TotalSeasonPoints { get; set; }
}