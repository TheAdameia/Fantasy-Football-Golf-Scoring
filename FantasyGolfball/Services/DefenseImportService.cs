using System.Globalization;
using CsvHelper;
using FantasyGolfball.Data;
using FantasyGolfball.Models.Utilities;
using FantasyGolfball.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;


public interface IDefenseImportService
{
    Task<int> ImportDefenseFromCsvAsync(Stream fileStream, int seasonId, CancellationToken cancellationToken);
}

public class DefenseImportService : IDefenseImportService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DefenseImportService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<int> ImportDefenseFromCsvAsync(Stream fileStream, int seasonId, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();

        var scoresToAdd = new List<Scoring>();

        using var reader = new StreamReader(fileStream);

        // if this was going to be used more often, defining a config would be warranted.
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<ScoringCsvRow>();

        // team stuff starts
        var season = dbContext.Seasons.SingleOrDefault(s => s.SeasonId == seasonId);
        if (season == null)
        {
            Console.WriteLine($"Warning: Could not find Season for seasonId '{seasonId}, exiting.");
            return -1;
        }

        var teams = new List<Team>
        {
            new Team { TeamCity = "Arizona",     TeamName = "Cardinals",    Abbreviation = "ARI", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Atlanta",    TeamName = "Falcons",      Abbreviation = "ATL", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Baltimore",  TeamName = "Ravens",       Abbreviation = "BAL", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Buffalo",    TeamName = "Bills",        Abbreviation = "BUF", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Carolina",   TeamName = "Panthers",     Abbreviation = "CAR", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Chicago",    TeamName = "Bears",        Abbreviation = "CHI", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Cincinnati", TeamName = "Bengals",      Abbreviation = "CIN", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Cleveland",  TeamName = "Browns",       Abbreviation = "CLE", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Dallas",     TeamName = "Cowboys",      Abbreviation = "DAL", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Denver",    TeamName = "Broncos",      Abbreviation = "DEN", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Detroit",   TeamName = "Lions",        Abbreviation = "DET", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Green Bay", TeamName = "Packers",      Abbreviation = "GB", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Houston",   TeamName = "Texans",       Abbreviation = "HOU", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Indianapolis", TeamName = "Colts",     Abbreviation = "IND", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Jacksonville", TeamName = "Jaguars",    Abbreviation = "JAX", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Kansas City", TeamName = "Chiefs",      Abbreviation = "KC", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Las Vegas", TeamName = "Raiders",      Abbreviation = "LV", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Los Angeles", TeamName = "Chargers", Abbreviation = "LAC", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Los Angeles", TeamName = "Rams",    Abbreviation = "LAR", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Miami",     TeamName = "Dolphins",     Abbreviation = "MIA", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Minnesota", TeamName = "Vikings",      Abbreviation = "MIN", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "New England", TeamName = "Patriots",    Abbreviation = "NE", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "New Orleans", TeamName = "Saints",     Abbreviation = "NO", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "New York",  TeamName = "Giants",       Abbreviation = "NYG", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "New York",  TeamName = "Jets",         Abbreviation = "NYJ", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Philadelphia", TeamName = "Eagles",    Abbreviation = "PHI", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Pittsburgh", TeamName = "Steelers",    Abbreviation = "PIT", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "San Francisco", TeamName = "49ers",    Abbreviation = "SF", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Seattle",   TeamName = "Seahawks",     Abbreviation = "SEA", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Tampa Bay", TeamName = "Buccaneers",   Abbreviation = "TB", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Tennessee", TeamName = "Titans",       Abbreviation = "TEN", ByeWeek = 0, SeasonId = season.SeasonId },
            new Team { TeamCity = "Washington", TeamName = "Commanders",  Abbreviation = "WAS", ByeWeek = 0, SeasonId = season.SeasonId },
        };


        // historical name checks start
        if (season.SeasonYear <= 2019)
        {
            var changeTeam = teams.FirstOrDefault(t => t.Abbreviation == "WAS");
            if (changeTeam != null)
            {
                changeTeam.TeamName = "Redskins";
            }
        }
        if (season.SeasonYear == 2020 || season.SeasonYear == 2021)
        {
            var changeTeam = teams.FirstOrDefault(t => t.Abbreviation == "WAS");
            if (changeTeam != null)
            {
                changeTeam.TeamName = "Football Team";
            }
        }
        if (season.SeasonYear < 2020)
        {
            var changeTeam = teams.FirstOrDefault(t => t.Abbreviation == "LV");
            if (changeTeam != null)
            {
                changeTeam.TeamCity = "Oakland";
            }
        }
        if (season.SeasonYear < 2017)
        {
            var changeTeam = teams.FirstOrDefault(t => t.Abbreviation == "LAC");
            if (changeTeam != null)
            {
                changeTeam.TeamCity = "San Diego";
            }
        }
        if (season.SeasonYear < 2016)
        {
            var changeTeam = teams.FirstOrDefault(t => t.Abbreviation == "LAR");
            if (changeTeam != null)
            {
                changeTeam.TeamCity = "St. Louis";
            }
        }
        // historical name checks end

        var existingTeams = await dbContext.Teams
             .Where(t => t.SeasonId == seasonId)
             .Select(t => t.Abbreviation)
             .ToListAsync(cancellationToken);

        var newTeams = teams
            .Where(t => !existingTeams.Contains(t.Abbreviation))
            .ToList();

        var defensePlayers = new List<Player>();
        var playerTeamsToAdd = new List<PlayerTeam>();

        if (newTeams.Any())
        {
            foreach (var t in newTeams)
            {
                var defensePlayer = new Player
                {
                    PlayerFirstName = t.TeamCity,
                    PlayerLastName = t.TeamName,
                    PositionId = 6,
                    SeasonId = season.SeasonId,
                    GamesPlayed = season.SeasonWeeks,
                    ExternalId = $"DEF-{t.Abbreviation}-{season.SeasonYear}"
                };

                defensePlayers.Add(defensePlayer);

                playerTeamsToAdd.Add(new PlayerTeam
                {
                    Player = defensePlayer, // uses navigational property instead of hard coding thanks to EFC magic
                    Team = t,
                    TeamStartWeek = 1
                });
            }

            Console.WriteLine($"'{newTeams.Count()}' new teams were added to SeasonYear '{season.SeasonYear}'.");
        }
        else
        {
            Console.WriteLine($"No new teams were generated for SeasonYear '{season.SeasonYear}'.");
        }

        // team stuff ends here

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

            var teamAbbrev = row.Team;

            if (string.IsNullOrWhiteSpace(teamAbbrev))
            {
                Console.WriteLine($"Warning: missing team in row for week '{row.Week}', season '{season.SeasonYear}', skipping.");
                continue;
            }

            var expectedExternalId = $"DEF-{teamAbbrev}-{season.SeasonYear}";

            var relevantPlayer = defensePlayers
                .SingleOrDefault(npt => npt.ExternalId == expectedExternalId);

            if (relevantPlayer == null)
            {
                relevantPlayer = await dbContext.Players
                    .SingleOrDefaultAsync(p => p.ExternalId == expectedExternalId, cancellationToken);
            }

            if (relevantPlayer == null)
            {
                Console.WriteLine($"Warning: could not find defense for team '{teamAbbrev}', week '{row.Week}', season '{season.SeasonYear}', skipping.");
                continue;
            }

            var newScoring = new Scoring
            {
                SeasonId = seasonId,
                IsDefense = true,
                Player = relevantPlayer,
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

            if ((decimal)newScoring.Points == row.FantasyPoints)
            {
                Console.WriteLine($"Scoring anomaly detected: PlayerId '{newScoring.PlayerId}', week '{newScoring.SeasonWeek}', calculated score '{newScoring.Points}', imported score '{row.FantasyPoints}'");
            }

            scoresToAdd.Add(newScoring);
        }

        // bye week inference begins
        var groupedByTeam = scoresToAdd
            .Where(s => s.Player != null)
            .GroupBy(s => s.Player.ExternalId);

        foreach (var group in groupedByTeam)
        {
            var externalId = group.Key;
            var scoredWeeks = group.Select(s => s.SeasonWeek).Distinct().ToHashSet();

            var byeWeek = Enumerable.Range(1, season.SeasonWeeks)
                                    .Except(scoredWeeks)
                                    .SingleOrDefault();

            if (byeWeek == 0)
            {
                Console.WriteLine($"Warning: No bye week set for '{group.Key}'");
                continue;
            }

            var parts = externalId.Split('-');
            if (parts.Length < 3)
            {
                Console.WriteLine($"Warning: potential malformed externalId for '{externalId}', '{group}'");
                continue;
            }
            var abbreviation = parts[1];

            var team = newTeams.SingleOrDefault(t => t.Abbreviation.Trim().ToUpper() == abbreviation.Trim().ToUpper());

            if (team != null)
            {
                team.ByeWeek = byeWeek;
            }
            else
            {
                Console.WriteLine($"Warning: Team was not found for externalId '{externalId}' despite byeWeek '{byeWeek}' not being null.");
            }
        }

        // bye week inference ends
        dbContext.Teams.AddRange(newTeams);
        dbContext.Players.AddRange(defensePlayers);
        dbContext.PlayerTeams.AddRange(playerTeamsToAdd);
        dbContext.Scorings.AddRange(scoresToAdd);

        var result = await dbContext.SaveChangesAsync(cancellationToken);
        return result;
    }

}