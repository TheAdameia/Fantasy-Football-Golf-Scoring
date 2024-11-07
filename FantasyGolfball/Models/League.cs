using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class League
{
    public int LeagueId { get; set; }
    // speculative way of storing userIds, storing userprofiles would probably be a bad idea
    public List<int> Participants { get; set; }
    public int PlayerLimit { get; set; }
    public bool RandomizedDraftOrder { get; set; }
    public bool UsersVetoTrades { get; set; }
    public string LeagueName { get; set; }
    public bool RequiredFullToStart { get; set; }
}