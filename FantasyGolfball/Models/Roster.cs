using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Roster
{
    public int RosterId { get; set; }
    public int LeagueId { get; set; }
    public int UserId { get; set; }
}