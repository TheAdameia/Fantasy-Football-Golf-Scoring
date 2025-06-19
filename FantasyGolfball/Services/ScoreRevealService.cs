using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using FantasyGolfball.Data;
using Microsoft.AspNetCore.SignalR;

namespace FantasyGolfball.Services;

// this is supposed to be a concurrent service rather than a loop like WAS.
// that means that it should be able to handle a higher load and be more accurate time-wise.
public class ScoreRevealService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IHubContext<ScoreRevealHub> _hubContext;
    private readonly ConcurrentDictionary<int, Task> _leagueTasks = new();
    private readonly ConcurrentDictionary<int, CancellationTokenSource> _cancellationTokens = new();

    public ScoreRevealService(IServiceScopeFactory scopeFactory, IHubContext<ScoreRevealHub> hubContext)
    {
        _scopeFactory = scopeFactory;
        _hubContext = hubContext;
    }

    public void StartRevealLoopForLeague(int leagueId)
    {
        if (_leagueTasks.ContainsKey(leagueId))
        {
            return;
        }

        var cts = new CancellationTokenSource();
        _cancellationTokens[leagueId] = cts;

        var task = Task.Run(() => RunLeagueRevealLoop(leagueId, cts.Token), cts.Token);
        _leagueTasks[leagueId] = task;
    }

    public void StopRevealLoop(int leagueId)
    {
        if (_cancellationTokens.TryRemove(leagueId, out var cts))
        {
            cts.Cancel();
        }

        _leagueTasks.TryRemove(leagueId, out _);
    }

    private async Task RunLeagueRevealLoop(int leagueId, CancellationToken token)
    {
        try
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();

            var revealSequence = new[] { "DEF", "K", "FLEX", "RB2", "WR2", "RB1", "WR1", "QB1" };
            var delayPerPosition = TimeSpan.FromSeconds(30); // can change this to be dependent on advancement

            foreach (var position in revealSequence)
            {
                if (token.IsCancellationRequested) break;

                await Task.Delay(delayPerPosition, token);

                var league = await db.Leagues
                    .FirstOrDefaultAsync(l => l.LeagueId == leagueId, token);

                if (league == null) continue;

                var matchups = await db.Matchups
                    .Where(m => m.LeagueId == leagueId && m.WeekId == league.CurrentWeek)
                    .Include(m => m.MatchupUsers)
                    .ToListAsync(token);

                if (!matchups.Any()) continue;


                foreach (var matchup in matchups)
                {
                    foreach (var user in matchup.MatchupUsers)
                    {
                        await _hubContext.Clients
                            .Group($"League-{league.LeagueId}")
                            .SendAsync("ReceiveScoreReveal", user.UserProfileId, position, cancellationToken: token);
                    }
                }
            }

            StopRevealLoop(leagueId); //cleanup when sequence completes
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"League {leagueId} reveal task cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Reveal loop error in league {leagueId}: {ex.Message}");
        }
    }
}