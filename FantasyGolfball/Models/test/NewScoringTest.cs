using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.Test;


// What else could Scoring use?
// Opposing team as a navigational property. For the sake of displaying the
// actual game that was played. Maybe a new class with more info on the date
// and time. Something to think about.
public class NewScoringTest
{
    [Key]
    public int ScoringId { get; set; }
    public int PlayerId { get; set; }
    public int SeasonId { get; set; }
    public int SeasonWeek { get; set; }
    public bool IsDefense { get; set; }

    // stats start here
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
    public int? Fumbles { get; set; } // NOTE: QB DOES NOT RECORD FOR THESE, BUT DOES FACTOR IN
    public int? FumbleLost { get; set; } // NOTE: QB DOES NOT RECORD FOR THESE, BUT DOES FACTOR IN
    public int? TwoExtraPoints { get; set; }
    public int? FieldGoalAttempts { get; set; } // not breaking these down by distance for stat reasons
    public int? FieldGoalsMade { get; set; }
    public int? ExtraPointAttempts { get; set; }
    public int? ExtraPointMade { get; set; }
    public int? PointsAgainst { get; set; } // DEF only stat, check IsDefense before factoring in
    public int? Sacks { get; set; }
    public int? InterceptionDefense { get; set; }
    public int? DefenseFumbleRecovery { get; set; }
    public int? Safety { get; set; }
    public int? TouchdownsDefense { get; set; }
    public int? TouchdownsReturn { get; set; }
    public int? BlockedKicks { get; set; }

    public float Points
    {
        get
        {
            float totalPoints = 0;

            if (!IsDefense)
            {
                totalPoints += (FieldGoalsMade ?? 0) * 3;
                totalPoints += (ExtraPointMade ?? 0) * 1;
                totalPoints += (TwoExtraPoints ?? 0) * 2;
                totalPoints += (Receptions ?? 0) * 0.5f;
                totalPoints += (YardsReceiving ?? 0) * 0.1f;
                totalPoints += (TouchdownsReceiving ?? 0) * 6;
                totalPoints += (YardsPassing ?? 0) * 0.04f;
                totalPoints += (TouchdownsPassing ?? 0) * 4;
                totalPoints += (YardsRushing ?? 0) * 0.1f;
                totalPoints += (TouchdownsRushing ?? 0) * 6;
                totalPoints += (FumbleLost ?? 0) * -2;
            }
            else // Defense
            {
                int pa = PointsAgainst ?? 0;
                if (pa == 0)
                    totalPoints += 10;
                else if (pa >= 1 && pa <= 6)
                    totalPoints += 7;
                else if (pa >= 7 && pa <= 13)
                    totalPoints += 4;
                else if (pa >= 14 && pa <= 20)
                    totalPoints += 1;
                else if (pa >= 21 && pa <= 27)
                    totalPoints += 0;
                else if (pa >= 28 && pa <= 34)
                    totalPoints -= 1;
                else if (pa >= 35)
                    totalPoints -= 4;

                totalPoints += (Sacks ?? 0) * 1;
                totalPoints += (InterceptionDefense ?? 0) * 2;
                totalPoints += (TouchdownsDefense ?? 0) * 6;
                totalPoints += (DefenseFumbleRecovery ?? 0) * 2;
                totalPoints += (TouchdownsReturn ?? 0) * 6;
                totalPoints += (Safety ?? 0) * 2;
                totalPoints += (BlockedKicks ?? 0) * 2;
            }

            return totalPoints;
        }
    }
}


