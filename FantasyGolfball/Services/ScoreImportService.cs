using System.Globalization;
using CsvHelper;
using FantasyGolfball.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using FantasyGolfball.Models.Utilities;
using FantasyGolfball.Models;
namespace FantasyGolfball.Services;


public interface IScoringImportService
{
    Task<int> ImportScoringFromCsvAsync(Stream fileStream, int seasonId, CancellationToken cancellationToken);
}

public class ScoringImportService : IScoringImportService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ScoringImportService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<int> ImportScoringFromCsvAsync(Stream fileStream, int seasonId, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();

        var scoresToAdd = new List<Scoring>();
        var playerTeamsToAdd = new List<PlayerTeam>();
        var playerStatusesToAdd = new List<PlayerStatus>();

        using var reader = new StreamReader(fileStream);

        // if this was going to be used more often than it was, defining a config would be warranted.
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<ScoringCsvRow>();

        // this runs off the assumption, which should be safe here, that the weeks are sequential in order and the players are sequential.
        string? previousPlayerId = null;
        string? previousTeam = null;

        foreach (var row in records)
        {
            if (string.IsNullOrWhiteSpace(row.Week))
            {
                Console.WriteLine($"Warning: week '{row.Week}' for player '{row.PlayerID}' is null or whitespace, skipping.");
                continue;
            }
            
            var match = Regex.Match(row.Week, @"(\d+)$");
            if (!match.Success || !int.TryParse(match.Value, out var weekSanitized))
            {
                Console.WriteLine($"Warning: could not extract week number from '{row.Week}' for player '{row.PlayerID}', skipping.");
                continue;
            }

            var relevantPlayer = dbContext.Players.SingleOrDefault(npt => npt.ExternalId == row.PlayerID); // potential performance increase here by caching the player
            if (relevantPlayer == null)
            {
                Console.WriteLine($"Warning: could not find player for ID '{row.PlayerID}', week '{row.Week}', skipping.");
                continue;
            };

            var newScoring = new Scoring
            {
                SeasonId = seasonId,
                IsDefense = false,
                PlayerId = relevantPlayer.PlayerId,
                SeasonWeek = weekSanitized,
                Completions = row.Completions ?? 0,
                AttemptsPassing = row.AttemptsPassing ?? 0,
                YardsPassing = row.YardsPassing ?? 0,
                TouchdownsPassing = row.TouchdownsPassing ?? 0,
                Interceptions = row.Interceptions ?? 0,
                Targets = row.Targets ?? 0,
                Receptions = row.Receptions ?? 0,
                YardsReceiving = row.YardsReceiving ?? 0,
                TouchdownsReceiving = row.TouchdownsReceiving ?? 0,
                AttemptsRushing = row.AttemptsRushing ?? 0,
                YardsRushing = row.YardsRushing ?? 0,
                TouchdownsRushing = row.TouchdownsRushing ?? 0,
                Fumbles = row.Fumbles ?? 0,
                FumbleLost = row.FumblesLost ?? 0,
                TwoExtraPoints = row.TwoExtraPoints ?? 0,
                FieldGoalAttempts = row.FieldGoalAttempts ?? 0,
                FieldGoalsMade = row.FieldGoalsMade ?? 0,
                ExtraPointAttempts = row.ExtraPointAttempts ?? 0,
                ExtraPointMade = row.ExtraPointMade ?? 0,
                PointsAgainst = row.PointsAgainst ?? 0,
                Sacks = row.Sacks ?? 0,
                InterceptionDefense = row.InterceptionDefense ?? 0,
                DefenseFumbleRecovery = row.DefenseFumbleRecovery ?? 0,
                Safety = row.Safety ?? 0,
                TouchdownsDefense = row.TouchdownsDefense ?? 0,
                TouchdownsReturn = row.TouchdownsReturn ?? 0,
                BlockedKicks = row.BlockedKicks ?? 0
            };


            // block that deals with PlayerStatus begins here
            // iterating through positions to check if there is any activity on the score
            bool isScoreValid = relevantPlayer.PositionId switch
            {
                // no need for ternaries since these statements resolve to bools
                1 => newScoring.AttemptsPassing != 0 || newScoring.AttemptsRushing != 0, 
                2 => newScoring.Receptions != 0 || newScoring.AttemptsRushing != 0 || newScoring.YardsReceiving != 0, 
                3 => newScoring.Receptions != 0 || newScoring.AttemptsRushing != 0 || newScoring.YardsRushing != 0,
                4 => newScoring.Receptions != 0 || newScoring.AttemptsRushing != 0 || newScoring.YardsReceiving != 0, 
                5 => newScoring.FieldGoalAttempts != 0 || newScoring.FieldGoalsMade != 0 || newScoring.ExtraPointAttempts != 0 || newScoring.ExtraPointMade != 0,
                6 => true,
                _ => false
            };

            var relevantPlayerStatus = dbContext.PlayerStatuses
                .SingleOrDefault(rps => rps.PlayerId == relevantPlayer.PlayerId && rps.StatusStartWeek == newScoring.SeasonWeek);

            if (relevantPlayerStatus == null && isScoreValid == false)
            {
                playerStatusesToAdd.Add(new PlayerStatus
                {
                    PlayerId = relevantPlayer.PlayerId,
                    StatusStartWeek = newScoring.SeasonWeek,
                    StatusId = 7
                });
            }
            else if (relevantPlayerStatus == null && isScoreValid)
            {
                playerStatusesToAdd.Add(new PlayerStatus
                {
                    PlayerId = relevantPlayer.PlayerId,
                    StatusStartWeek = newScoring.SeasonWeek,
                    StatusId = 1
                });
            }
            else if (relevantPlayerStatus != null && isScoreValid == false)
            {
                relevantPlayerStatus.StatusId = 7;
            }
            // block that deals with PlayerStatus ends here


            // block that identifies if a player changes teams
            if (previousPlayerId != null && previousTeam != null)
            {
                if (previousPlayerId == row.PlayerID && previousTeam != row.Team)
                {

                    var newTeam = dbContext.Teams.SingleOrDefault(t => t.SeasonId == newScoring.SeasonId && t.Abbreviation == row.Team);

                    if (newTeam != null)
                    {
                        playerTeamsToAdd.Add(new PlayerTeam
                        {
                            PlayerId = newScoring.PlayerId,
                            TeamId = newTeam.TeamId,
                            TeamStartWeek = newScoring.SeasonWeek
                        });
                    }

                    Console.WriteLine($"Player '{previousPlayerId}' changed from '{previousTeam}' to '{row.Team}' in week '{newScoring.SeasonWeek}' ");
                }
            }

            // log scores that don't match, should be an issue for D (no blocked kicks) and QB (no fumble)

            previousPlayerId = row.PlayerID;
            previousTeam = row.Team;

            scoresToAdd.Add(newScoring);

        }

        dbContext.Scorings.AddRange(scoresToAdd);
        dbContext.PlayerTeams.AddRange(playerTeamsToAdd);
        dbContext.PlayerStatuses.AddRange(playerStatusesToAdd);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        return result;
    }
}