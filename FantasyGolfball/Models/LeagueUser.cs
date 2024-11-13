using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class LeagueUser
{
    public int LeagueUserId { get; set; }
    public int LeagueId { get; set; }
    public int UserId { get; set; }
}