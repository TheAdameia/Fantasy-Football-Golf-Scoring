
namespace FantasyGolfball.Models.DTOs;

public class PlayerStatusDTO
{
    public int PlayerStatusId { get; set; }
    public int PlayerId { get; set; }
    public int StatusId { get; set; }
    public StatusDTO Status { get; set; }
    public int StatusStartWeek { get; set; }

}