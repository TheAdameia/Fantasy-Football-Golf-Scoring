using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class MatchupUserSavedPlayerDTO
{
    public int MatchupUserSavedPlayerId { get; set; }
    public int MatchupUserId { get; set; }
    public int PlayerId { get; set; }
    public PlayerFullExpandDTO Player { get; set; }
    public int ScoringId { get; set; }
    public ScoringDTO Scoring { get; set; }
}