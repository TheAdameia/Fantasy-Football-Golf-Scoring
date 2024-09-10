using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class PlayerStatus
{
    public int PlayerStatusId { get; set; }
    public int PlayerId { get; set; }
    public int StatusId { get; set; }
}