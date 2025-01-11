namespace FantasyGolfball.Services;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Models.DTOs;

public interface IDraftService
{
    Task<DraftState> GetDraftState(int leagueId);
    Task<DraftState> SelectPlayer(int leagueId, int userId, int playerId, int maxRosterSize);
}

public class DraftService : IDraftService
{
    private readonly FantasyGolfballDbContext _dbContext;
    private readonly Dictionary<int, DraftState> _draftStates = new();

    public DraftService(FantasyGolfballDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); // Ensure dbContext is injected correctly
    }

    public async Task<DraftState> GetDraftState(int leagueId)
    {
        if (!_draftStates.ContainsKey(leagueId))
        {
            // initialize draft state from db
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

        }

        return _draftStates[leagueId];
    }

    public async Task<DraftState> SelectPlayer(int leagueId, int userId, int playerId, int maxRosterSize)
    {
        var draftState = await GetDraftState(leagueId);
        draftState.SelectPlayer(userId, playerId, maxRosterSize);

        // update db
        var roster = await _dbContext.Rosters.FirstOrDefaultAsync(r => r.LeagueId == leagueId && r.UserId == userId);
        
        if (roster == null) 
        {
            throw new Exception($"Roster not found for user {userId} in league {leagueId}");
        }

        _dbContext.RosterPlayers.Add(new RosterPlayer
        {
            PlayerId = playerId,
            RosterId = roster.RosterId
        });

        await _dbContext.SaveChangesAsync();
        return draftState;
    }
}