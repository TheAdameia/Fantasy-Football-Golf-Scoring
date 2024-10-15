using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class PositionDTO
{
    [Key]
    public int PositionId { get; set; }
    public string PositionShort { get; set; }
    public string PositionLong { get; set; }
}