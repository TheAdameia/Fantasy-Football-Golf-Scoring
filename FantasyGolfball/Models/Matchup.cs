using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Matchup
{
    public int MatchupId { get; set; }
    public int LeagueId { get; set; }
    public ICollection<MatchupUser> MatchupUsers { get; set; } = new List<MatchupUser>();
}