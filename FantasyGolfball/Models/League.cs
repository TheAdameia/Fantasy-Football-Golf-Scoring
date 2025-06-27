using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public enum AdvancementType
{
    Weekly,
    Daily,
    Hourly,
    Turbo
}
public class League
{
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
    public Season Season { get; set; }
    public ICollection<LeagueUser> LeagueUsers { get; set; }
    public DateTime DraftStartTime { get; set; }
    public DateTime SeasonStartDate { get; set; }
    public AdvancementType Advancement { get; set; } = AdvancementType.Weekly; // defaults to weekly
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
            else if (Advancement == AdvancementType.Hourly)
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
    public int? LastRecordedWeek { get; set; } // key exists to assist in detecting when CurrentWeek changes
    public string? JoinPassword { get; set; }
    public bool RequiresPassword { get; set; }
}