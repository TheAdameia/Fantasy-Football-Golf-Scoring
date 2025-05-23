
namespace FantasyGolfball.Models.DTOs;

public class PlayerTeamDTO
{
    public int PlayerTeamId { get; set; }
    public int PlayerId { get; set; }
    public int TeamId { get; set; }
    public TeamDTO Team { get; set; }
    public int TeamStartWeek { get; set; } // indicates when the player started being on the team.
}