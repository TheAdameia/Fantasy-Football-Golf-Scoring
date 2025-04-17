using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class MatchupUserDTO
{
    public int MatchupUserId { get; set; }
    public int UserProfileId { get; set; }
    public UserProfileSafeExportDTO UserProfileDTO { get; set; }
    public int MatchupId { get; set; }
}