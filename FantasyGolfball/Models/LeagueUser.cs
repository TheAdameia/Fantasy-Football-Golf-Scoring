using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class LeagueUser
{
    public int LeagueUserId { get; set; }
    public int LeagueId { get; set; }
    public int UserProfileId { get; set; }
    public League League { get; set; }
    public UserProfile UserProfile { get; set; }
}