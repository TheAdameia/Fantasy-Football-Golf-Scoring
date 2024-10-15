using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class StatusDTO
{
    [Key]
    public int StatusId { get; set; }
    public string StatusType { get; set; }
    public bool ViableToPlay { get; set; }
    public bool RequiresBackup { get; set; }
}