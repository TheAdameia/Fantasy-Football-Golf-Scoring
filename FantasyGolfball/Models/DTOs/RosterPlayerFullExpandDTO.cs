using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class RosterPlayerFullExpandDTO
{
    [Key]
    public int RosterPlayerId { get; set; }
    public int PlayerId { get; set; }
    public PlayerFullExpandDTO Player { get; set; }
    public string RosterPosition { get; set; }
    public int RosterId { get; set; }
}