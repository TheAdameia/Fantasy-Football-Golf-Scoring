using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;

namespace FantasyGolfball.Models;
public class DraftState
{
    public int LeagueId { get; set; }
    public Queue<int> DraftOrder { get; private set; }
    public Queue<int> PermanentDraftOrder { get; private set; }
    public List<PlayerFullExpandDTO> AvailablePlayers { get; private set; }
    public List<PlayerFullExpandDTO> PermanentPlayers { get; private set; }
    public Dictionary<int, List<int>> UserRosters { get; private set; } // UserId -> PlayerIds

    public DraftState(int leagueId, List<PlayerFullExpandDTO> playerPool, List<int> userOrder)
    {
        LeagueId = leagueId;
        AvailablePlayers = new List<PlayerFullExpandDTO>(playerPool);
        PermanentPlayers = new List<PlayerFullExpandDTO>(playerPool);
        DraftOrder = new Queue<int>(GenerateDraftOrder(userOrder, 15)); // 15 should be replaced with MaxRosterSize if that ever changes
        PermanentDraftOrder = new Queue<int>(GenerateDraftOrder(userOrder, 15));
        UserRosters = userOrder.ToDictionary(id => id, _ => new List<int>());
    }

    private IEnumerable<int>GenerateDraftOrder(List<int> userIds, int rounds)
    {
        var order = new List<int>();
        for (int round = 0; round < rounds; round++)
        {
            if (round % 2 == 0) // reverses order every other round to accomplish snake draft format
            {
                order.AddRange(userIds); 
            }
            else
            {
                order.AddRange(userIds.AsEnumerable().Reverse());
            }
        }

        return order;
    }

    public int CurrentUserId => DraftOrder.Peek();

    public void SelectPlayer(int userId, int playerId, int maxRosterSize)
    {
        if (userId != CurrentUserId)
            throw new InvalidOperationException($"Not this user's turn. userId read as {userId}. Current turn is for user {CurrentUserId}");
        if (!AvailablePlayers.Any(p => p.PlayerId == playerId))
            throw new InvalidOperationException("Player not available.");
        if (UserRosters[userId].Count >= maxRosterSize)
            throw new InvalidOperationException("Cannot exceed maximum roster size.");

        var selectedPlayer = AvailablePlayers.First(p => p.PlayerId == playerId);
        AvailablePlayers.Remove(selectedPlayer);
        UserRosters[userId].Add(playerId);

        if (DraftOrder.Count > 0) // Always ensure the queue has elements before dequeuing
        {
          DraftOrder.Dequeue();
        }
        else
        {
            Console.WriteLine("DraftOrder is empty. Ending draft");
        }
    }
    public bool AllUsersHaveFullRosters(int maxRosterSize) // this should work because the "roster" here is just a list of IDs, not the actual roster in the dbcontext
    {
        return UserRosters.Values.All(roster => roster.Count >= maxRosterSize);
    }

    public bool IsDraftComplete() => AvailablePlayers.Count == 0 || DraftOrder.Count == 0;
}
