using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class LeagueFullExpandDTO
{
    [Key]
    public int LeagueId { get; set; }
    public int PlayerLimit { get; set; }
    public bool RandomizedDraftOrder { get; set; }
    public bool UsersVetoTrades { get; set; }
    public string LeagueName { get; set; }
    public bool RequiredFullToStart { get; set; }
    public int MaxRosterSize { get; set; }
    public bool IsDraftComplete { get; set; }
    public int SeasonId { get; set; }
    public ICollection<LeagueUserFullExpandDTO> LeagueUsers { get; set; }
}