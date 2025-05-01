using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

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
    public string? JoinPassword { get; set; }
    public bool RequiresPassword { get; set; }
}