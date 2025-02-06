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
}