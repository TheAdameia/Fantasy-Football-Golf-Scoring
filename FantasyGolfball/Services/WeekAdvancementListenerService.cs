namespace FantasyGolfball.Services;

using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.Events;
using Microsoft.EntityFrameworkCore;

public class WeekAdvancementListenerService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IEventBus _eventBus;

    public WeekAdvancementListenerService(IEventBus eventBus, IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        _eventBus = eventBus;

        eventBus.Subscribe<WeekAdvancedEvent>(HandleWeekAdvanced);
    }

    private async Task HandleWeekAdvanced(WeekAdvancedEvent eventData)
    {
        Console.WriteLine($"Performing updates for League {eventData.LeagueId} now in Week {eventData.NewWeek}");

        using var scope = _scopeFactory.CreateScope(); // creates a new scope to ensure fresh db
        var dbContext = scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();

        var league = await dbContext.Leagues
            .Include(l => l.Season)
            .FirstOrDefaultAsync(l => l.LeagueId == eventData.LeagueId);

        if (league == null)
        {
            throw new Exception($"League {eventData.LeagueId} not found in WALS");
        }

        int previousWeek = eventData.NewWeek - 1;
        if (previousWeek == 0)
        {
            Console.WriteLine($"Skipping score calculation for League {eventData.LeagueId} because previousWeek is 0.");
            // I think SRE is not firing in week 0 -> 1 because of this, but that is easily remedied here
            await _eventBus.Publish(new ScoreRevealEvent(league.LeagueId, eventData.NewWeek));
            Console.WriteLine($"SRE fired for League {league.LeagueId}, Week {eventData.NewWeek}.");
            return;
        }


        // league finish code begins here
        if (previousWeek >= league.Season.SeasonWeeks && !league.IsLeagueFinished)
        {
            league.IsLeagueFinished = true;
            Console.WriteLine($"League {league.LeagueId} set to finished");
            dbContext.SaveChanges();
            return;
        }
        if (league.IsLeagueFinished)
        {
            Console.WriteLine($"Warning: League {league.LeagueId} skipped in WALS due to already being done. This shouldn't happen due to WAS filters.");
            return;
        }
        // league finish code ends here

        // matchup resolution begins here
        var matchups = await dbContext.Matchups
            .Where(m => m.LeagueId == league.LeagueId && m.WeekId == previousWeek)
            .Include(m => m.MatchupUsers)
            .ThenInclude(mu => mu.userProfile)
            .ToListAsync();

        foreach (var matchup in matchups)
        {
            if (matchup.MatchupUsers.Count != 2)
            {
                throw new Exception($"Warning: matchup '{matchup.MatchupId}' contains a non-2 number of MU");
            }

            var scores = new Dictionary<int, float>(); // key: userprofileid, value: sum score

            foreach (var matchupUser in matchup.MatchupUsers)
            {
                var roster = await dbContext.Rosters
                    .Where(r => r.UserId == matchupUser.UserProfileId && r.LeagueId == league.LeagueId)
                    .Include(r => r.RosterPlayers)
                        .ThenInclude(rp => rp.Player)
                            .ThenInclude(p => p.Position)
                    .FirstOrDefaultAsync();

                if (roster == null)
                {
                    throw new Exception($"In WALS, user {matchupUser.UserProfileId} in league {league.LeagueId} did not return a roster");
                }

                // for the SavedPlayers
                var AllRosterPlayers = roster.RosterPlayers
                    .ToList();

                var AllPlayerIds = AllRosterPlayers
                    .Select(rp => rp.PlayerId)
                    .ToList();

                var scoringEntries = await dbContext.Scorings
                    .Where(s => s.SeasonId == league.SeasonId &&
                                s.SeasonWeek == previousWeek &&
                                AllPlayerIds.Contains(s.PlayerId))
                    .ToListAsync();

                // RosterPlayers filtered in memory instead of in the query because the .where doesn't translate into EFC
                var ActiveRosterPlayers = AllRosterPlayers
                    .Where(rp => rp.RosterPosition != "bench")
                    .ToList();

                float totalScore = 0;

                foreach (var arp in ActiveRosterPlayers)
                {
                    var scoring = scoringEntries.FirstOrDefault(s => s.PlayerId == arp.PlayerId);
                    float pointsPlusPenalty = 0;

                    // eliminates bye weeks and no-Scoring weeks
                    // penalizes QBs harder than other positions
                    if (scoring == null)
                    {
                        if (arp.Player.Position.PositionId == 1)
                        {
                            pointsPlusPenalty = pointsPlusPenalty + 15;
                            continue;
                        } else
                        {
                            pointsPlusPenalty = pointsPlusPenalty + 10;
                            continue;
                        }
                    }

                    // adds points
                    if (scoring.Points != 0)
                    {
                        pointsPlusPenalty = pointsPlusPenalty + scoring.Points;
                    }

                    // adds penalty points if conditions are met
                    if (scoring.Points == 0 && pointsPlusPenalty == 0) 
                    {
                        switch (arp.Player.Position.PositionId)
                        {
                            case 1: // QB
                                if (scoring.YardsPassing == 0 &&
                                    scoring.YardsRushing == 0 &&
                                    scoring.AttemptsPassing == 0 &&
                                    scoring.AttemptsRushing == 0 &&
                                    scoring.FumbleLost == 0 &&
                                    scoring.Interceptions == 0)
                                {
                                    pointsPlusPenalty = pointsPlusPenalty + 15;
                                }
                                break;
                            case 2: // WR
                            case 3: // RB
                            case 4: // TE
                                if (scoring.YardsReceiving == 0 &&
                                    scoring.YardsRushing == 0 &&
                                    scoring.Targets == 0 &&
                                    scoring.Receptions == 0 &&
                                    scoring.AttemptsRushing == 0 &&
                                    scoring.FumbleLost == 0)
                                {
                                    pointsPlusPenalty = pointsPlusPenalty + 10;
                                }
                                break;
                            case 5: // K
                                if (scoring.FieldGoalAttempts == 0 && 
                                    scoring.FieldGoalsMade == 0 &&
                                    scoring.ExtraPointAttempts == 0 &&
                                    scoring.ExtraPointMade == 0)
                                {
                                    pointsPlusPenalty = pointsPlusPenalty + 10;
                                }
                                break;
                            case 6: // DEF
                                // no checks needed: this should never trigger. DEF only doesn't play on bye weeks,
                                // which are covered before.
                                break ;
                            default:
                                Console.WriteLine($"Warning: In WALS, an invalid PositionId was found for RosterPlayer {arp.RosterPlayerId}in League {eventData.LeagueId}");
                                break;
                        }
                    }

                    // adds to the total
                    totalScore = totalScore + pointsPlusPenalty;
                }

                // penalizes users who don't start players
                // would need modification if alternate roster structures ever existed
                if (ActiveRosterPlayers.Count() < 9)
                {
                    totalScore = totalScore + ((9 - ActiveRosterPlayers.Count()) * 15);
                }

                scores[matchupUser.UserProfileId] = totalScore;

                // saves what the roster was so it can be excavated for past matchups display
                matchupUser.MatchupUserSavedPlayers = AllRosterPlayers
                    .Select(rp =>
                    {
                        var scoring = scoringEntries.FirstOrDefault(s => s.PlayerId == rp.PlayerId);

                        if (scoring == null)
                        {
                            Console.WriteLine($"Warning: Player {rp.PlayerId} in MatchupUser {matchupUser.MatchupUserId} did not have a scoring entry for Week {previousWeek}. Using fallback scoring ID 1.");

                            return new MatchupUserSavedPlayer
                            {
                                MatchupUserId = matchupUser.MatchupUserId,
                                PlayerId = rp.PlayerId,
                                ScoringId = 1,
                                RosterPlayerPosition = rp.RosterPosition
                            };
                        }

                        return new MatchupUserSavedPlayer
                        {
                            MatchupUserId = matchupUser.MatchupUserId,
                            PlayerId = rp.PlayerId,
                            ScoringId = scoring.ScoringId,
                            RosterPlayerPosition = rp.RosterPosition
                        };
                    }).ToList();
            }
            
            // the reason this if is here is it allows for the possibility of more than 2 player MUs.
            if (scores.Count == 2)
            {
                var winner = scores.OrderBy(kv => kv.Value).First(); // sorts lowest to highest score, lowest wins
                matchup.WinnerId = winner.Key;
            } 
        } 
        // matchup resolution ends here

        await dbContext.SaveChangesAsync();
        Console.WriteLine($"Completed Week Advancement matchup processing for League {league.LeagueId}.");

        await _eventBus.Publish(new TradeProcessingEvent(league.LeagueId, eventData.NewWeek));
        Console.WriteLine($"TPE fired for League {league.LeagueId}, Week {eventData.NewWeek}.");

        await _eventBus.Publish(new ScoreRevealEvent(league.LeagueId, eventData.NewWeek));
        Console.WriteLine($"SRE fired for League {league.LeagueId}, Week {eventData.NewWeek}.");
        
    }
}