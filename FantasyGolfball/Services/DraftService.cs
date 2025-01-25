namespace FantasyGolfball.Services;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Models.DTOs;

public interface IDraftService
{
    Task<DraftState> GetDraftState(int leagueId);
    Task<DraftState> SelectPlayer(int leagueId, int userId, int playerId, int maxRosterSize);
    void UpdateDraftState(int leagueId, DraftState updatedState);
}



public class DraftService : IDraftService
{
    private readonly FantasyGolfballDbContext _dbContext;
    private readonly Dictionary<int, DraftState> _draftStates = new();

    public DraftService(FantasyGolfballDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); // Ensure dbContext is injected correctly
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
            // grabs league from db
            var league = await _dbContext.Leagues
                .Include(l => l.LeagueUsers)
                .FirstOrDefaultAsync(l => l.LeagueId == leagueId);

            if (league == null)
                throw new Exception($"League {leagueId} not found");

            var availablePlayers = await _dbContext.Players
                .Where(p => !p.RosterPlayers.Any(rp => rp.Roster.LeagueId == leagueId))
                .Include(p => p.Status)
                .Include(p => p.Position)
                .Select(p => new PlayerFullExpandDTO
                {
                    PlayerId = p.PlayerId,
                    PlayerFirstName = p.PlayerFirstName,
                    PlayerLastName = p.PlayerLastName,
                    StatusId = p.StatusId,
                    PositionId = p.PositionId,
                    Position = new PositionDTO
                    {
                        PositionId = p.Position.PositionId,
                        PositionShort = p.Position.PositionShort,
                        PositionLong = p.Position.PositionLong
                    },
                    Status = new StatusDTO
                    {
                        StatusId = p.Status.StatusId,
                        StatusType = p.Status.StatusType,
                        ViableToPlay = p.Status.ViableToPlay,
                        RequiresBackup = p.Status.RequiresBackup
                    }
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

        // // Log the current state of the draft order before processing
        // Console.WriteLine($"[Before Selection] DraftOrder: {string.Join(", ", draftState.DraftOrder)}");
        // Console.WriteLine($"[Before Selection] Current User ID: {draftState.CurrentUserId}");

        // do the thing, zhu li
        draftState.SelectPlayer(userId, playerId, maxRosterSize);

        UpdateDraftState(leagueId, draftState);
        // // Log the state after modifying the draft
        // Console.WriteLine($"[After Selection] DraftOrder: {string.Join(", ", draftState.DraftOrder)}");
        // Console.WriteLine($"[After Selection] Current User ID: {draftState.CurrentUserId}");


        // update db
        var roster = await _dbContext.Rosters.FirstOrDefaultAsync(r => r.LeagueId == leagueId && r.UserId == userId);
        if (roster == null) 
        {
            throw new Exception($"Roster not found for user {userId} in league {leagueId}");
        }

        _dbContext.RosterPlayers.Add(new RosterPlayer
        {
            PlayerId = playerId,
            RosterId = roster.RosterId,
            RosterPosition = "bench"
        });

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database save error: {ex.Message}");
            throw;
        }

        // // Log final state confirmation
        // Console.WriteLine($"Draft process completed for User {userId} in League {leagueId}.");
        // Console.WriteLine($"[Final State] DraftOrder: {string.Join(", ", draftState.DraftOrder)}");
        
        return draftState;
    }
}