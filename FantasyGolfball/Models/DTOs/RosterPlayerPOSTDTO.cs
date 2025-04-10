using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class RosterPlayerPOSTDTO
{
    [Required]
    public int PlayerId { get; set; }
    [Required]
    public int RosterId { get; set; }
}