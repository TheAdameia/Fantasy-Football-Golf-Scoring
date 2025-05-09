using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Player
{
    public int PlayerId { get; set; }
    public string PlayerFirstName { get; set;}
    public string PlayerLastName { get; set; }
    public int PositionId { get; set; }
    public ICollection<RosterPlayer> RosterPlayers { get; set; }
    public Position Position { get; set; }
    public ICollection<PlayerStatus> PlayerStatuses { get; set; }
    public ICollection<PlayerTeam> PlayerTeams { get; set; }
    public int SeasonId { get; set; }
    public string PlayerFullName
    {
        get
        {
            return $"{PlayerFirstName} {PlayerLastName}";
        }
    }
}