

namespace FantasyGolfball.Models;

public class Season
{
    public int SeasonId { get; set; }
    public int SeasonYear { get; set; }

    // the idea is that... there will be premade seasons for the actual, real season.
    // but if people want to "replay" a past season, a new instance of the class is created
    // with an identical year, and it can proceed as fast as they want it to. Leagues would
    // need a seasonId and the Season property RealSeason would be checked to determine how
    // logic for things such as adding/dropping players operates.

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
    public int? LastRecordedWeek { get; set; } // key exists to assist in detecting when CurrentWeek changes
}