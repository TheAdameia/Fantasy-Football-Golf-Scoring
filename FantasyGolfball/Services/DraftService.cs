namespace FantasyGolfball.Services;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Models.DTOs;
using Microsoft.Extensions.DependencyInjection;
using FantasyGolfball.Models.Events;
public interface IDraftService
{
    Task<DraftState> GetDraftState(int leagueId);
    Task<DraftState> SelectPlayer(int leagueId, int userId, int playerId, int maxRosterSize);
    void UpdateDraftState(int leagueId, DraftState updatedState);
}



public class DraftService : IDraftService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly Dictionary<int, DraftState> _draftStates = new();
    private readonly IEventBus _eventBus;

    public DraftService(IServiceScopeFactory scopeFactory, IEventBus eventBus)
    {
        _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        _eventBus = eventBus;
    }

     private FantasyGolfballDbContext GetDbContext()
    {
        var scope = _scopeFactory.CreateScope();
        return scope.ServiceProvider.GetRequiredService<FantasyGolfballDbContext>();
    }

    public void UpdateDraftState(int leagueId, DraftState updatedState)
    {
        if (_draftStates.ContainsKey(leagueId))
        {
            _draftStates[leagueId] = updatedState;
            Console.WriteLine($"Updated DraftState for League {leagueId}. CurrentUserId: {updatedState.CurrentUserId}");
        }
        else
        {
            throw new Exception($"DraftState for League {leagueId} does not exist.");
        }
    }

    public async Task<DraftState> GetDraftState(int leagueId)
    {
        if (!_draftStates.ContainsKey(leagueId))
        {
            using var dbContext = GetDbContext();
            // grabs league from db
            var league = await dbContext.Leagues
                .Include(l => l.LeagueUsers)
                .FirstOrDefaultAsync(l => l.LeagueId == leagueId);

            if (league == null)
                throw new Exception($"League {leagueId} not found");

            var availablePlayers = await dbContext.Players
                .Where(p => !p.RosterPlayers.Any(rp => rp.Roster.LeagueId == leagueId))
                .Select(p => new PlayerFullExpandDTO
                {
                    PlayerId = p.PlayerId,
                    PlayerFirstName = p.PlayerFirstName,
                    PlayerLastName = p.PlayerLastName,
                    PositionId = p.PositionId,
                    Position = new PositionDTO
                    {
                        PositionId = p.Position.PositionId,
                        PositionShort = p.Position.PositionShort,
                        PositionLong = p.Position.PositionLong
                    },
                    PlayerStatuses = p.PlayerStatuses.Select(ps => new PlayerStatusDTO
                    {
                        PlayerStatusId = ps.PlayerStatusId,
                        PlayerId = ps.PlayerId,
                        StatusId = ps.StatusId,
                        StatusStartWeek = ps.StatusStartWeek,
                        Status = new StatusDTO
                        {
                            StatusId = ps.Status.StatusId,
                            StatusType = ps.Status.StatusType,
                            ViableToPlay = ps.Status.ViableToPlay,
                            RequiresBackup = ps.Status.RequiresBackup
                        }
                    }).ToList(),
                })
                .ToListAsync();
            
            // fetches user ids
            var userIds = league.LeagueUsers.Select(lu => lu.UserProfileId).ToList();

            // initializes draft state
            _draftStates[leagueId] = new DraftState(leagueId, availablePlayers, userIds);
            Console.WriteLine($"DraftState initialized with leagueId {leagueId}, userIds {userIds}");
        }
        else
        {
            Console.WriteLine($"Retrieved existing DraftState for League {leagueId}. CurrentUserId: {_draftStates[leagueId].CurrentUserId}");
        }

        return _draftStates[leagueId];
    }

    public async Task<DraftState> SelectPlayer(int leagueId, int userId, int playerId, int maxRosterSize)
    {
        using var dbContext = GetDbContext();
        // validate inputs
        if (leagueId <= 0 || userId <= 0 || playerId <= 0 || maxRosterSize <= 0)
        {
            throw new ArgumentException($"Invalid input(s): leagueId={leagueId}, userId={userId}, playerId={playerId}, maxRosterSize={maxRosterSize}");
        }

        // retrieve draft state
        var draftState = await GetDraftState(leagueId);
        if (draftState == null)
        {
            throw new Exception($"Draft state not found for league {leagueId}");
        }

        // do the thing, zhu li
        draftState.SelectPlayer(userId, playerId, maxRosterSize);

        UpdateDraftState(leagueId, draftState);

        // update db
        var roster = await dbContext.Rosters.FirstOrDefaultAsync(r => r.LeagueId == leagueId && r.UserId == userId);
        if (roster == null) 
        {
            throw new Exception($"Roster not found for user {userId} in league {leagueId}");
        }

        dbContext.RosterPlayers.Add(new RosterPlayer
        {
            PlayerId = playerId,
            RosterId = roster.RosterId,
            RosterPosition = "bench"
        });

        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database save error: {ex.Message}");
            throw;
        }

        // **Check if draft is complete**
        bool draftComplete = draftState.AllUsersHaveFullRosters(maxRosterSize) || draftState.IsDraftComplete();
        if (draftComplete)
        {
            await CompleteDraft(leagueId); // Triggers draft completion event
            Console.WriteLine($"Draft completion check: IsDraftComplete={draftState.IsDraftComplete()}, AllUsersHaveFullRosters={draftState.AllUsersHaveFullRosters(maxRosterSize)}");

        }
        return draftState;
    }

    public async Task CompleteDraft(int leagueId)
    {
        using var dbContext = GetDbContext();

        var draftState = await GetDraftState(leagueId);
        if (draftState == null)
        {
            throw new Exception($"Draft state not found for league {leagueId} in CompleteDraft");
        }

        var league = await dbContext.Leagues.FirstOrDefaultAsync(l => l.LeagueId == leagueId);
        if (league == null)
        {
            throw new Exception($"League {leagueId} not found");
        }

        var SavedDraftState = new HistoricalDraftState
        {
            LeagueId = draftState.LeagueId,
            PermanentDraftOrder = draftState.PermanentDraftOrder,
            UserRosters = draftState.UserRosters
        };

        dbContext.HistoricalDraftStates.Add(SavedDraftState);
        league.IsDraftComplete = true;
        await dbContext.SaveChangesAsync();

        Console.WriteLine($"Draft for League {leagueId} marked as completed. Historical DraftState saved.");

        // publish event
        try
        {
            await _eventBus.Publish(leagueId);
        }
        catch (Exception ex)
        {
            
            throw new Exception($"Something went wrong publishing draft completed event, ex: {ex}");
        }
        
    }
}