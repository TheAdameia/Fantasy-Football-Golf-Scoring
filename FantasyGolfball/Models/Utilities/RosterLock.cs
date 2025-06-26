namespace FantasyGolfball.Models.Utilities;

using FantasyGolfball.Models;

public static class RosterLockCheck
{
    public static bool IsRosterLocked(League league, DateTime? overrideNow = null) // override for potential future use, testing
    {
        if (league.CurrentWeek == null)
            return false;

        var now = overrideNow ?? DateTime.UtcNow;
        var currentWeek = league.CurrentWeek.Value;
        var seasonStart = league.SeasonStartDate;

        TimeSpan msPerWeek;
        TimeSpan totalRevealDuration;

        switch (league.Advancement)
        {
            case AdvancementType.Weekly:
                msPerWeek = TimeSpan.FromDays(7);
                totalRevealDuration = TimeSpan.FromHours(8);
                break;
            case AdvancementType.Daily:
                msPerWeek = TimeSpan.FromDays(1);
                totalRevealDuration = TimeSpan.FromHours(1);
                break;
            case AdvancementType.Hourly:
                msPerWeek = TimeSpan.FromHours(1);
                totalRevealDuration = TimeSpan.FromMinutes(10);
                break;
            case AdvancementType.Turbo:
                msPerWeek = TimeSpan.FromMinutes(15);
                totalRevealDuration = TimeSpan.FromMinutes(5);
                break;
            default:
                return false;
        }

        var nextWeekTime = seasonStart + msPerWeek * currentWeek;
        var revealStartTime = nextWeekTime - totalRevealDuration;

        return now >= revealStartTime && now <= nextWeekTime;
    }
}
