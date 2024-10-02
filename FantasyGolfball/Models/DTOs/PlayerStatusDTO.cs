using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class PlayerStatusDTO
{
    [Key]
    public int PlayerStatusId { get; set; }
    public int PlayerId { get; set; }
    public int StatusId { get; set; }
}