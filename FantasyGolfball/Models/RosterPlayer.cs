using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class RosterPlayer
{
    public int RosterPlayerId { get; set; }
    public int PlayerId { get; set; }
    public int RosterId { get; set; }
    public Roster Roster { get; set; }
    public Player Player { get; set; }
}