using Microsoft.AspNetCore.Identity;

namespace FantasyGolfball.Models;

public class League
{
    public int LeagueId { get; set; }
    // speculative way of storing userIds, storing userprofiles would be a bad idea
    public List<int> Participants { get; set; }
}