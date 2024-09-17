using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Player
{
    public int PlayerId { get; set; }
    public string PlayerFirstName { get; set;}
    public string PlayerLastName { get; set; }
    public int PositionId { get; set; }
}