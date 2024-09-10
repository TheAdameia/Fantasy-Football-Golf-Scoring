using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class Position
{
    public int PositionId { get; set; }
    public string PositionShort { get; set; }
    public string PositionLong { get; set; }   
}