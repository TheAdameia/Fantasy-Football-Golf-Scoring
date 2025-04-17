using System.ComponentModel.DataAnnotations;

namespace FantasyGolfball.Models.DTOs;

public class RegistrationDTO
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Email { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Password { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string UserName { get; set; }
}