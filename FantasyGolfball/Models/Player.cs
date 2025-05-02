using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Player
{
    public int PlayerId { get; set; }
    public string PlayerFirstName { get; set;}
    public string PlayerLastName { get; set; }
    public int PositionId { get; set; }
    public int StatusId { get; set; }
    public ICollection<RosterPlayer> RosterPlayers { get; set; }
    public Position Position { get; set; }
    public Status Status { get; set;}
    public ICollection<PlayerTeam> PlayerTeams { get; set; }
    public string PlayerFullName
    {
        get
        {
            return $"{PlayerFirstName} {PlayerLastName}";
        }
    }
}