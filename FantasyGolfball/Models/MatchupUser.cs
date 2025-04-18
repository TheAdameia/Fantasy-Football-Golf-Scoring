using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class MatchupUser
{
    public int MatchupUserId { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile userProfile { get; set; }
    public int MatchupId { get; set; }
    public Matchup matchup { get; set; }
    public ICollection<MatchupUserSavedPlayer> MatchupUserSavedPlayers { get; set; }
}