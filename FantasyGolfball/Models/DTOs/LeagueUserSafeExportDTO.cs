using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class LeagueUser
{
    [Key]
    public int LeagueUserId { get; set; }
    public int LeagueId { get; set; }
    public int UserId { get; set; }
    public UserProfileSafeExportDTO UserProfile { get; set; }
}