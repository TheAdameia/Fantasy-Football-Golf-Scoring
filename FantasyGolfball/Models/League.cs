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
    public ICollection<LeagueUser> LeagueUsers { get; set; }
}