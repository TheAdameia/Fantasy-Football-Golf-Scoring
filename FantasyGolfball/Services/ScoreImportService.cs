using System.Globalization;
using CsvHelper;
using FantasyGolfball.Data;
using FantasyGolfball.Models.Test;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

// this will assuredly be a horrible kluge of switch case due to how the data is formatted.
// however, I have some options.
// I can make this a kluge... or I can make the scraper a kluge. Decisions, decisions.

// It would probably be better to make the scraper a kluge so that if I ever have to use a different
// source, I can re-use the service by having the scraper match the format.

namespace FantasyGolfball.Services;
// make sure to instantiate this in program.cs

public class ScoringCsvRow
{
    public int Completions { get; set; }
    public int AttemptsPassing { get; set; }
    public int YardsPassing { get; set; }
    public int TouchdownsPassing { get; set; }
    public int Interceptions { get; set; }
    public int Targets { get; set; }
    public int Receptions { get; set; }
    public int YardsReceiving { get; set; }
    public int TouchdownsReceiving { get; set; }
    public int AttemptsRushing { get; set; }
    public int YardsRushing { get; set; }
    public int TouchdownsRushing { get; set; }
    public int Fumbles { get; set; }
    public int FumblesLost { get; set; }
    public int TwoExtraPoints { get; set; }
    public int FieldGoalAttempts { get; set; }
    public int FieldGoalsMade { get; set; }
    public int ExtraPointAttempts { get; set; }
    public int ExtraPointMade { get; set; }
    public int PointsAgainst { get; set; }
    public int Sacks { get; set; }
    public int InterceptionDefense { get; set; }
    public int DefenseFumbleRecovery { get; set; }
    public int Safety { get; set; }
    public int TouchdownsDefense { get; set; }
    public int TouchdownsReturn { get; set; }
    public int BlockedKicks { get; set; }
    public int FantasyPoints { get; set; }
    public string Week { get; set; }
    public string PlayerID { get; set; }
    public string Position { get; set; }
}

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

        var scoresToAdd = new List<NewScoringTest>();

        using var reader = new StreamReader(fileStream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<ScoringCsvRow>();

        foreach (var row in records)
        {
            // ok, so what else does this need?
            // needs to detect if team changes from one week to the next
            // do I want an invalid status? Maybe later?
            // Definitely later.
            
            int weekSanitized = 99;

            if (string.IsNullOrEmpty(row.Week))
            {
                Console.WriteLine($"Warning: week {row.Week} for player {row.PlayerID} is invalid, skipping.");
            }
            else
            {
                var match = Regex.Match(row.Week, @"(\d+)$"); // match one or more digits at the end
                if (match.Success)
                {
                    weekSanitized = int.Parse(match.Value);
                }
                else
                {
                    Console.WriteLine($"Warning: Could not extract week number from '{row.Week}' for player {row.PlayerID}, skipping.");
                    continue;
                }
            }

            var relevantPlayer = dbContext.NewPlayerTests.SingleOrDefault(npt => npt.ExternalId == row.PlayerID);
            if (relevantPlayer == null)
            {
                Console.WriteLine($"Warning: Could not find player for ID {row.PlayerID}, week {row.Week}, skipping.");
                continue;
            };

            var newScoring = new NewScoringTest
            {
                SeasonId = seasonId,
                IsDefense = false,
                PlayerId = relevantPlayer.PlayerId,
                SeasonWeek = weekSanitized,
                Completions = row.Completions,
                AttemptsPassing = row.AttemptsPassing,
                YardsPassing = row.YardsPassing,
                TouchdownsPassing = row.TouchdownsPassing,
                Interceptions = row.Interceptions,
                Targets = row.Targets,
                Receptions = row.Receptions,
                YardsReceiving = row.YardsReceiving,
                TouchdownsReceiving = row.TouchdownsReceiving,
                AttemptsRushing = row.AttemptsRushing,
                YardsRushing = row.YardsRushing,
                TouchdownsRushing = row.TouchdownsRushing,
                Fumbles = row.Fumbles,
                FumbleLost = row.FumblesLost,
                TwoExtraPoints = row.TwoExtraPoints,
                FieldGoalAttempts = row.FieldGoalAttempts,
                FieldGoalsMade = row.FieldGoalsMade,
                ExtraPointAttempts = row.ExtraPointAttempts,
                ExtraPointMade = row.ExtraPointMade,
                PointsAgainst = row.PointsAgainst,
                Sacks = row.Sacks,
                InterceptionDefense = row.InterceptionDefense,
                DefenseFumbleRecovery = row.DefenseFumbleRecovery,
                Safety = row.Safety,
                TouchdownsDefense = row.TouchdownsDefense,
                TouchdownsReturn = row.TouchdownsReturn,
                BlockedKicks = row.BlockedKicks
            };

            scoresToAdd.Add(newScoring);

        }

        dbContext.NewScoringTests.AddRange(scoresToAdd);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        return result;
    }
}