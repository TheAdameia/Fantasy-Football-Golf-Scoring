namespace FantasyGolfball.Models.DTOs;

public class SeasonDTO
{
    public int SeasonId { get; set; }
    public int SeasonYear { get; set; }
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
    public bool RealSeason { get; set; }
    public AdvancementType Advancement { get; set; }
}