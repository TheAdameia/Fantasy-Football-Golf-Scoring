
namespace FantasyGolfball.Models;

public class PlayerStatus
{
    public int PlayerStatusId { get; set; }
    public int PlayerId { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
    public int StatusStartWeek { get; set; }
}