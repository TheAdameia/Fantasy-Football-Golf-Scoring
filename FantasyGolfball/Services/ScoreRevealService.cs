using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using FantasyGolfball.Data;
using Microsoft.AspNetCore.SignalR;
using FantasyGolfball.Models;
using FantasyGolfball.Models.Events;

namespace FantasyGolfball.Services;

// this is supposed to be a concurrent service rather than a loop like WAS.
// that means that it should be able to handle a higher load and be more accurate time-wise.
public class ScoreRevealService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IHubContext<ScoreRevealHub> _hubContext;
    private readonly ConcurrentDictionary<int, Task> _leagueTasks = new();
    private readonly ConcurrentDictionary<int, CancellationTokenSource> _cancellationTokens = new();

    public ScoreRevealService(IServiceScopeFactory scopeFactory, IHubContext<ScoreRevealHub> hubContext, IEventBus eventBus)
    {
        _scopeFactory = scopeFactory;
        _hubContext = hubContext;
        eventBus.Subscribe<ScoreRevealEvent>(async e =>
        {
            Console.WriteLine($"ScoreRevealService received event for League {e.LeagueId}, Week {e.WeekNumber}");
            StartRevealLoopForLeague(e.LeagueId);
            await Task.CompletedTask;
        });
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

            // make it so that it starts firing in time for them to be all done by the time of the week advancement

             var league = await db.Leagues
                .FirstOrDefaultAsync(l => l.LeagueId == leagueId, token);

            if (league == null || league.CurrentWeek == null)
            {
                Console.WriteLine($"Exiting SRS for League {leagueId}, CurrentWeek or league was null");
                return;
            }

            var startTime = DateTime.UtcNow;

            // calculates when next week starts
            DateTime nextWeekTime;
            switch (league.Advancement)
            {
                case AdvancementType.Weekly:
                    nextWeekTime = league.SeasonStartDate.AddDays(7 * league.CurrentWeek.Value);
                    break;
                case AdvancementType.Daily:
                    nextWeekTime = league.SeasonStartDate.AddDays(league.CurrentWeek.Value);
                    break;
                case AdvancementType.Hourly:
                    nextWeekTime = league.SeasonStartDate.AddHours(league.CurrentWeek.Value);
                    break;
                default:
                    throw new InvalidOperationException("Unknown AdvancementType.");
            }

            // calculates total reveal window
            TimeSpan totalRevealDuration;
            switch (league.Advancement)
            {
                case AdvancementType.Weekly:
                    totalRevealDuration = TimeSpan.FromHours(8);
                    break;
                case AdvancementType.Daily:
                    totalRevealDuration = TimeSpan.FromMinutes(60);
                    break;
                case AdvancementType.Hourly:
                    totalRevealDuration = TimeSpan.FromMinutes(10);
                    break;
                default:
                    totalRevealDuration = TimeSpan.FromMinutes(30);
                    break;
            }

            var revealStartTime = nextWeekTime - totalRevealDuration;
            var now = DateTime.UtcNow;

            // sets task to activate when relevant
            if (now < revealStartTime)
            {
                var waitTime = revealStartTime - now;
                Console.WriteLine($"[League {leagueId}] Waiting {waitTime} until reveal starts.");
                await Task.Delay(waitTime, token);
            }

            var revealInterval = TimeSpan.FromMilliseconds(totalRevealDuration.TotalMilliseconds / revealSequence.Length);

            foreach (var position in revealSequence)
            {
                if (token.IsCancellationRequested) break;

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