using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class PlayerFullExpandDTO
{
    [Key]
    public int PlayerId { get; set; }
    public string PlayerFirstName { get; set;}
    public string PlayerLastName { get; set; }
    public int PositionId { get; set; }
    public int StatusId { get; set; }
    public PositionDTO Position { get; set; }
    public List<PlayerStatusDTO> PlayerStatuses { get; set; }
    public List<PlayerTeamDTO> PlayerTeams { get; set; }
    public string PlayerFullName
    {
        get
        {
            return $"{PlayerFirstName} {PlayerLastName}";
        }
    }
}