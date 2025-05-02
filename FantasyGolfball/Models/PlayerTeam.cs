
namespace FantasyGolfball.Models;

public class PlayerTeam
{
    public int PlayerTeamId { get; set; }
    public int PlayerId { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
    public int TeamStartWeek { get; set; } // indicates when the player started being on the team.
    public int? TeamEndWeek { get; set; } // indicates when the player left the team. Nullable to show that the player is still on the team.
}