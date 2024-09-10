using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Matchup
{
    public int MatchupId { get; set; }
    public int LeagueId { get; set; }
    public int UserProfileId1 { get; set; }
    public int UserProfileId2 { get; set; }
}