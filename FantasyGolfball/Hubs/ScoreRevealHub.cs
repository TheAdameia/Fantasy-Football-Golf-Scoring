using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class ScoreRevealHub : Hub
{
    // call to reveal per rosterPosition
    public async Task SendScoreReveal(int leagueId, string rosterPosition)
    {
        await Clients.Group($"League-{leagueId}")
            .SendAsync("ReceiveScoreReveal", rosterPosition);
    }

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var leagueId = httpContext.Request.Query["leagueId"];
        var userId = httpContext.Request.Query["userId"];

        if (!string.IsNullOrEmpty(leagueId))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"League-{leagueId}");
        }

        // Optionally group by user to allow 1:1 targeting
        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"User-{userId}");
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        // remove from group on disconnect
        var httpContext = Context.GetHttpContext();
        var leagueId = httpContext.Request.Query["leagueId"];
        var userId = httpContext.Request.Query["userId"];

        if (!string.IsNullOrEmpty(leagueId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"League-{leagueId}");
        }

        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"User-{userId}");
        }

        await base.OnDisconnectedAsync(exception);
    }
}