using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class UserProfileSafeExportDTO
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; }
}