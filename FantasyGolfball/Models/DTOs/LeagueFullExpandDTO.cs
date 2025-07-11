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
    public bool IsLeagueFinished { get; set; }
    public int SeasonId { get; set; }
    public DateTime DraftStartTime { get; set; }
    public SeasonDTO Season { get; set; }
    public ICollection<LeagueUserFullExpandDTO> LeagueUsers { get; set; }
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
                else if (Advancement == AdvancementType.Turbo)
                {
                    weekNumber = (int)((now - SeasonStartDate).TotalMinutes / 15) + 1; // treats every 15 minutes as a "week"
                }

                return weekNumber;
            }
    }
    public AdvancementType Advancement { get; set; }
}