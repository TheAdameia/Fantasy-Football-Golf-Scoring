using System.Globalization;
using CsvHelper;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyGolfball.Services;

public class PlayerCsvRow
{
    public required string Rank { get; set; }
    public required string Name { get; set; }
    public required string Team { get; set; }
    public required string Pos { get; set; }
    public int GP { get; set; }
    public required string PlayerID { get; set; }
    
}

public interface IPlayerImportService
{
    Task<int> ImportPlayersFromCsvAsync(Stream fileStream, int seasonId, CancellationToken cancellationToken);
}

public class PlayerImportService : IPlayerImportService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public PlayerImportService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<int> ImportPlayersFromCsvAsync(Stream fileStream, int seasonId, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();

        var playersToAdd = new List<Player>();
        var playerStatusesToAdd = new List<PlayerStatus>();

        using var reader = new StreamReader(fileStream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<PlayerCsvRow>();

        foreach (var row in records)
        {
            var nameParts = row.Name.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            var firstName = nameParts.Length > 1 ? nameParts[0] : "";
            var lastName = nameParts.Length > 1 ? nameParts[1] : nameParts[0];

            var position = 0;
            switch (row.Pos)
            {
                case "QB":
                    position = 1;
                    break;
                case "WR":
                    position = 2;
                    break;
                case "RB":
                    position = 3;
                    break;
                case "TE":
                    position = 4;
                    break;
                case "K":
                    position = 5;
                    break;
                case "DST":
                    position = 6;
                    break;
            }

            if (position == 0)
                throw new Exception($"Position '{row.Pos}' not found for {row.Name}.");

            var newPlayer = new Player
            {
                PlayerFirstName = firstName,
                PlayerLastName = lastName,
                PositionId = position,
                GamesPlayed = row.GP,
                SeasonId = seasonId,
                Scorings = new List<Scoring>(),
                RosterPlayers = new List<RosterPlayer>(),
                PlayerStatuses = new List<PlayerStatus>(),
                PlayerTeams = new List<PlayerTeam>(),
                ExternalId = row.PlayerID
            };

            playersToAdd.Add(newPlayer);

            playerStatusesToAdd.Add(new PlayerStatus
            {
                Player = newPlayer,
                StatusId = 1,
                StatusStartWeek = 1
            });
        }

        dbContext.Players.AddRange(playersToAdd);
        dbContext.PlayerStatuses.AddRange(playerStatusesToAdd);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        return result;
    }
}
