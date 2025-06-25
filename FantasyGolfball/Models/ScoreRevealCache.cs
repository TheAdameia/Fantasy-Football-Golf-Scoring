using System.Collections.Concurrent;
namespace FantasyGolfball.Models;

public class RevealEntry
{
    public HashSet<string> Positions { get; set; } = new();
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}

public static class ScoreRevealCache
{
    private static readonly ConcurrentDictionary<(int LeagueId, int WeekId), RevealEntry> _revealedPositions = new();

    private static readonly object _lock = new();

    public static void AddRevealedPosition(int leagueId, int weekId, string position)
    {
        var key = (leagueId, weekId);
        lock (_lock)
        {
            if (!_revealedPositions.TryGetValue(key, out var entry))
            {
                entry = new RevealEntry();
                _revealedPositions[key] = entry;
            }

            entry.Positions.Add(position);
            entry.LastUpdated = DateTime.UtcNow;
        }
    }

    public static List<string> GetRevealedPositions(int leagueId, int weekId)
    {
        var key = (leagueId, weekId);
        if (_revealedPositions.TryGetValue(key, out var entry))
        {
            return entry.Positions.ToList();
        }

        return new List<string>();
    }

    public static void StartCleanup(TimeSpan expiration)
    {
        Timer _timer = new Timer(_ =>
        {
            var cutoff = DateTime.UtcNow - expiration;

            lock (_lock)
            {
                var expired = _revealedPositions
                    .Where(kvp => kvp.Value.LastUpdated < cutoff)
                    .Select(kvp => kvp.Key)
                    .ToList();

                foreach (var key in expired)
                {
                    if (_revealedPositions.TryRemove(key, out var entry))
                    {
                        Console.WriteLine($"Removed cache for league {key.LeagueId}, positions: {string.Join(",", entry.Positions)}");
                    }
                }
            }
        }, null, TimeSpan.Zero, TimeSpan.FromHours(1));
    }

}
