using Microsoft.AspNetCore.SignalR;

public class LiveDraftHub : Hub
{
    private readonly IDraftService _draftService;

    public LiveDraftHub(IDraftService draftService)
    {
        _draftService = draftService;
    }

    // called when a user connects to the draft
    public async Task JoinDraft(int leagueId)
    {
        string groupName = $"League_{leagueId}";
        try
        {
            // Add user to the group
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            Console.WriteLine($"User {Context.ConnectionId} joined group {groupName}");

            // Get the draft state
            var draftState = await _draftService.GetDraftState(leagueId);

            if (draftState == null)
            {
                Console.WriteLine($"Draft state for league {leagueId} is null");
                return;
            }

            // Send draft state to the client
            await Clients.Caller.SendAsync("DraftStateUpdated", draftState);
            Console.WriteLine($"Draft state for league {leagueId} sent to {Context.ConnectionId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in JoinDraft: {ex.Message}");
            await Clients.Caller.SendAsync("Error", ex.Message);
        }
    }


    // called when a user drafts a player
    public async Task SelectPlayer(int leagueId, int userId, int playerId)
    {
        try
        {
            var updatedState = await _draftService.SelectPlayer(leagueId, userId, playerId);
            await Clients.Group($"League_{leagueId}").SendAsync("DraftStateUpdated", updatedState); // notifies all clients
        }
        catch (Exception ex)
        {
            await Clients.Caller.SendAsync("Error", ex.Message);
        }
    }

    // server sends current turn update
    public async Task NotifyTurn(int leagueId, int userId)
    {
        await Clients.Group($"League_{leagueId}").SendAsync("TurnUpdated", userId);
    }
}