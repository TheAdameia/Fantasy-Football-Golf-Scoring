using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class MatchupUserSavedPlayer
{
    public int MatchupUserSavedPlayerId { get; set; }
    public int MatchupUserId { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; }
    public int ScoringId { get; set; }
    public Scoring Scoring { get; set; }
    public string RosterPlayerPosition { get; set; }
}