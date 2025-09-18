namespace FantasyGolfball.Models.Utilities;

public class ScoringCsvRow
{
    public int? Completions { get; set; }
    public int? AttemptsPassing { get; set; }
    public int? YardsPassing { get; set; }
    public int? TouchdownsPassing { get; set; }
    public int? Interceptions { get; set; }
    public int? Targets { get; set; }
    public int? Receptions { get; set; }
    public int? YardsReceiving { get; set; }
    public int? TouchdownsReceiving { get; set; }
    public int? AttemptsRushing { get; set; }
    public int? YardsRushing { get; set; }
    public int? TouchdownsRushing { get; set; }
    public int? Fumbles { get; set; }
    public int? FumblesLost { get; set; }
    public int? TwoExtraPoints { get; set; }
    public int? FieldGoalAttempts { get; set; }
    public int? FieldGoalsMade { get; set; }
    public int? ExtraPointAttempts { get; set; }
    public int? ExtraPointMade { get; set; }
    public int? PointsAgainst { get; set; }
    public int? Sacks { get; set; }
    public int? InterceptionDefense { get; set; }
    public int? DefenseFumbleRecovery { get; set; }
    public int? Safety { get; set; }
    public int? TouchdownsDefense { get; set; }
    public int? TouchdownsReturn { get; set; }
    public int? BlockedKicks { get; set; }
    public decimal? FantasyPoints { get; set; }
    public required string Week { get; set; }
    public required string PlayerID { get; set; }
    public required string Position { get; set; }
    public required string Team { get; set; }
}