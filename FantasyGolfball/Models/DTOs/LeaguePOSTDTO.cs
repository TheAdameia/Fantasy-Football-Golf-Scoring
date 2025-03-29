using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class LeaguePOSTDTO
{
   public int CreatorId { get; set; }
   public string LeagueName { get; set; }
   public int PlayerLimit { get; set; }
   public bool RandomizedDraftOrder { get; set; }
   public bool UsersVetoTrades { get; set; }
   public bool RequiredFullToStart { get; set; }
   public int MaxRosterSize { get; set; }
   public int SeasonId { get; set; }
   public bool RealSeason { get; set; }
   public int SeasonYear { get; set; }
   public DateTime SeasonStartDate { get; set; }
   public DateTime DraftStartTime { get; set; }
   public string Advancement { get; set; }
}