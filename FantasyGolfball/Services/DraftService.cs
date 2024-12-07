using FantasyGolfball.Data;
using FantasyGolfball.Models;
using Microsoft.EntityFrameworkCore;

public interface IDraftService
{
    Task<DraftState> GetDraftState(int leagueId);
    Task<DraftState>SelectPlayer(int leagueId, int userId, int playerId);
}

public class DraftService
{
    private readonly FantasyGolfballDbContext _dbContext;
    private readonly Dictionary<int, DraftState> _draftStates = new();

    public DraftService(FantasyGolfballDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DraftState> GetDraftState(int leagueId)
    {
        if (!_draftStates.ContainsKey(leagueId))
        {
            // initialize draft state from db
            var league = await _dbContext.Leagues
                .Include(l => l.LeagueUsers)
                .FirstOrDefaultAsync(l => l.LeagueId == leagueId);

            var players = await _dbContext.Players
                .Where(p => !p.RosterPlayers.Any(rp => rp.Roster.LeagueId == leagueId))
                .Select(p => p.PlayerId)
                .ToListAsync();
            
            var userIds = league.LeagueUsers.Select(lu => lu.UserProfileId).ToList();
            _draftStates[leagueId] = new DraftState(leagueId, players, userIds);

        }

        return _draftStates[leagueId];
    }

    public async Task<DraftState> SelectPlayer(int leagueId, int userId, int playerId, int maxRosterSize)
    {
        var draftState = await GetDraftState(leagueId);
        draftState.SelectPlayer(userId, playerId, maxRosterSize);

        // save to db
        var roster = await _dbContext.Rosters.FirstOrDefaultAsync(r => r.LeagueId == leagueId && r.UserId == userId);
        _dbContext.RosterPlayers.Add(new RosterPlayer
        {
            PlayerId = playerId,
            RosterId = roster.RosterId
        });

        await _dbContext.SaveChangesAsync();
        return draftState;
    }
}