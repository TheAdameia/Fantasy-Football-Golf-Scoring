using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Scoring
{
    public int ScoringId { get; set; }
    public int PlayerId { get; set; }
    public int SeasonId { get; set; }
    public int SeasonWeek { get; set; }
    public float Points { get; set; }
}