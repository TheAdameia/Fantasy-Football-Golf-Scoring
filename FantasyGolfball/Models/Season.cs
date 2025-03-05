

namespace FantasyGolfball.Models;

public class Season
{
    public int SeasonId { get; set; }
    public int SeasonYear { get; set; }


    // the idea is that... there will be premade seasons for the actual, real season.
    // but if people want to "replay" a past season, a new instance of the class is created
    // with an identical year, and it can proceed as fast as they want it to.

    public bool RealSeason { get; set; }
}