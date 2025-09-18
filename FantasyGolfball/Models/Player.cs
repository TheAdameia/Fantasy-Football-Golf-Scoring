using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    public required string PlayerFirstName { get; set; }
    public required string PlayerLastName { get; set; }
    public int PositionId { get; set; }
    public ICollection<Scoring> Scorings { get; set; } // new
    public ICollection<RosterPlayer> RosterPlayers { get; set; }
    public Position Position { get; set; }
    public ICollection<PlayerStatus> PlayerStatuses { get; set; }
    public ICollection<PlayerTeam> PlayerTeams { get; set; }
    public int SeasonId { get; set; }
    public int GamesPlayed { get; set; } // new
    public string PlayerFullName
    {
        get
        {
            return $"{PlayerFirstName} {PlayerLastName}";
        }
    }
    public required string ExternalId { get; set; }
}