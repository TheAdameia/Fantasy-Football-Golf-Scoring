using Microsoft.AspNetCore.SignalR;
using FantasyGolfball.Services;
using System.Text.Json;

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

            // Ensure draft state is valid and not null
            if (draftState == null)
            {
                Console.WriteLine($"Draft state for league {leagueId} is null");
                return;
            }

            // Ensure all properties of the draftState are valid and serializable
            var draftStateJson = JsonSerializer.Serialize(draftState);
            Console.WriteLine($"Serialized DraftState JSON: {draftStateJson}");

            // Send draft state to the client
            await Clients.Caller.SendAsync("DraftStateUpdated", draftState);
            Console.WriteLine($"Draft state for league {leagueId} sent to {Context.ConnectionId}");

            // trigger NotifyTurn for the first user
            if (draftState.CurrentUserId != null)
            {
                Console.WriteLine($"Triggering NotifyTurn for user {draftState.CurrentUserId} in league {leagueId}");
                await NotifyTurn(leagueId, draftState.CurrentUserId.Value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in JoinDraft: {ex.Message}");
            await Clients.Caller.SendAsync("Error", ex.Message);
        }
    }

    // server sends current turn update
    public async Task NotifyTurn(int leagueId, int userId)
    {
        try
        {
            await Clients.Group($"League_{leagueId}").SendAsync("TurnUpdated", userId);
            Console.WriteLine($"Notifying User {userId} in League {leagueId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending TurnUpdated event: {ex.Message}");
        }
    }

    // called when a user drafts a player
    public async Task SelectPlayer(int leagueId, int userId, int playerId, int maxRosterSize)
    {
        Console.WriteLine($"SelectPlayer called: leagueId={leagueId}, userId={userId}, playerId={playerId}, maxRosterSize={maxRosterSize}");
        try
        {
            if (leagueId <= 0 || userId <= 0 || playerId <= 0 || maxRosterSize<= 0 )
            {
                
                throw new ArgumentException("invalid arguments passed to SelectPlayer");
            }
            var updatedState = await _draftService.SelectPlayer(leagueId, userId, playerId, maxRosterSize);
            await Clients.Group($"League_{leagueId}").SendAsync("DraftStateUpdated", updatedState); // notifies all clients
            if (updatedState.CurrentUserId.HasValue)
            {
                await NotifyTurn(leagueId, updatedState.CurrentUserId.Value);
            }
            else
            {
                Console.WriteLine("Draft has ended. No more turns to notify.");
                // this would be a good place to send a draft complete message or trigger for the UI
                await Clients.Group($"League_{leagueId}").SendAsync("DraftCompleted");
            }

            
            // var nextUserId = updatedState.CurrentUserId;
            // await NotifyTurn(leagueId, nextUserId);
        }
        catch (Exception ex)
        {
            await Clients.Caller.SendAsync("Error", ex.Message);
        }
    }
}