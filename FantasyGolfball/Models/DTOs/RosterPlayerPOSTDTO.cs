using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class RosterPlayerPOSTDTO
{
    public int RosterPlayerId { get; set; }
    public int PlayerId { get; set; }
    public int RosterId { get; set; }
    public string RosterPosition { get; set; }
}