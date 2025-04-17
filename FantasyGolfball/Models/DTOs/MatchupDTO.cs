using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class MatchupDTO
{
    public int MatchupId { get; set; }
    public int LeagueId { get; set; }
    public int WeekId { get; set; }
    public ICollection<MatchupUserDTO> MatchupUsers { get; set; } = new List<MatchupUserDTO>();
    public int? WinnerId { get; set; }
}