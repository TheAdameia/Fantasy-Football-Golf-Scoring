using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class LeaguePOSTDTO
{
   [Required]
   public int CreatorId { get; set; }
   [Required]
   [StringLength(100, MinimumLength = 3)]
   public required string LeagueName { get; set; }
   [Range(2, 8)]
   public int PlayerLimit { get; set; }
   public bool RandomizedDraftOrder { get; set; }
   public bool UsersVetoTrades { get; set; }
   public bool RequiredFullToStart { get; set; }
   [Range(1, 30)]
   public int MaxRosterSize { get; set; }
   public int SeasonYear { get; set; }
   [Required]
   public DateTime SeasonStartDate { get; set; }
   [Required]
   public DateTime DraftStartTime { get; set; }
   [Required]
   public string Advancement { get; set; }
   [StringLength(100)]
   public string? JoinPassword { get; set;}
   public bool RequiresPassword { get; set; }
}