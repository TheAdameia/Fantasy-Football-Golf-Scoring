

public class DraftState
{
    public int LeagueId { get; set; }
    public Queue<int> DraftOrder { get; private set; }
    public List<int> AvailablePlayers { get; private set; }
    public Dictionary<int, List<int>> UserRosters { get; private set; } // UserId -> PlayerIds

    public DraftState(int leagueId, List<int> playerPool, List<int> userOrder)
    {
        LeagueId = leagueId;
        AvailablePlayers = new List<int>(playerPool);
        DraftOrder = new Queue<int>(userOrder);
        UserRosters = userOrder.ToDictionary(id => id, _ => new List<int>());
    }

    public int CurrentUserId => DraftOrder.Peek();

    public void SelectPlayer(int userId, int playerId, int maxRosterSize)
    {
        if (userId != CurrentUserId)
            throw new InvalidOperationException("Not this user's turn.");
        if (!AvailablePlayers.Contains(playerId))
            throw new InvalidOperationException("Player not available.");
        if (UserRosters[userId].Count >= maxRosterSize)
            throw new InvalidOperationException("Cannot exceed maximum roster size.");

        AvailablePlayers.Remove(playerId);
        UserRosters[userId].Add(playerId);

        DraftOrder.Dequeue();
        if (DraftOrder.Count > 0)
            DraftOrder.Enqueue(CurrentUserId); // Snake draft order
    }

    public bool IsDraftComplete() => AvailablePlayers.Count == 0 || DraftOrder.Count == 0;
}
