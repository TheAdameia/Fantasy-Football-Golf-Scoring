using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }
}