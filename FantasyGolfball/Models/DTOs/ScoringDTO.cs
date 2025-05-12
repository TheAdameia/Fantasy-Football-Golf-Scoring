using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class ScoringDTO
{
    [Key]
    public int ScoringId { get; set; }
    public int PlayerId { get; set; }
    public int SeasonWeek { get; set; }
    public float Points { get; set; }
}