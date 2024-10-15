using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class RosterPOSTDTO
{
    [Key]
    public int RosterId { get; set; }
    public int LeagueId { get; set; }
    public int UserId { get; set; }
}