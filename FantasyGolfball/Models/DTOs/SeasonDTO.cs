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
            DateTime now = DateTime.Now;
            if (now < SeasonStartDate) return null; // season hasn't started

            int weekNumber = (int)((now - SeasonStartDate).TotalDays / 7) + 1;
            return weekNumber;
        }
    }
    public bool RealSeason { get; set; }
}