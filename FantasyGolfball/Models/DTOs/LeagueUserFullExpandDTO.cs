using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class LeagueUserFullExpandDTO
{
    [Key]
    public int LeagueUserId { get; set; }
    public int LeagueId { get; set; }
    public int UserProfileId { get; set; }
    public int RosterId { get; set; }
    public RosterFullExpandDTO Roster { get; set; }
    public UserProfileSafeExportDTO UserProfile { get; set; }
}