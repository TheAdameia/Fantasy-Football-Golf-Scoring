using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class RosterFullExpandDTO
{
    [Key]
    public int RosterId { get; set; }
    public int LeagueId { get; set; }
    public List<RosterPlayerFullExpandDTO> RosterPlayers { get; set; }
}