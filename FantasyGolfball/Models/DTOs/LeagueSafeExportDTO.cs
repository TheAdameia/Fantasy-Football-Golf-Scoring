using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models.DTOs;

public class LeagueSafeExportDTO
{
    [Key]
    public int LeagueId { get; set; }
    public int PlayerLimit { get; set; }
    public bool RandomizedDraftOrder { get; set; }
    public bool UsersVetoTrades { get; set; }
    public string LeagueName { get; set; }
    public bool RequiredFullToStart { get; set; }
    public int MaxRosterSize { get; set; }
    public int SeasonId { get; set; }
    public SeasonDTO Season { get; set; }
    public ICollection<LeagueUserSafeExportDTO> LeagueUsers { get; set; }
    public bool RequiresPassword { get; set; }
    public DateTime SeasonStartDate { get; set; }
    public int? CurrentWeek
    {
        get
            {
                DateTime now = DateTime.UtcNow;
                if (now < SeasonStartDate) return null; // season hasn't started

                int weekNumber = 0;

                if (Advancement == AdvancementType.Weekly)
                {
                    weekNumber = (int)((now - SeasonStartDate).TotalDays / 7) + 1;
                }
                else if (Advancement == AdvancementType.Daily)
                {
                    weekNumber = (int)((now - SeasonStartDate).TotalDays / 1) + 1; // treats each day as a "week"
                }
                else if (Advancement ==  AdvancementType.Hourly)
                {
                    weekNumber = (int)((now - SeasonStartDate).TotalHours / 1) + 1; // treats each hour as a "week"
                }

                return weekNumber;
            }
    }
    public AdvancementType Advancement { get; set; }
}