using FantasyGolfball.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/matchup-generation")]
public class MatchupGenerationController : ControllerBase
{
    private readonly IMatchupService _matchupService;

    public MatchupGenerationController(IMatchupService matchupService)
    {
        _matchupService = matchupService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GenerateMatchups([FromBody] GenerateMatchupsRequest request)
    {
        await _matchupService.GenerateMatchups(request.LeagueId, request.TotalWeeks, request.GamesPerPlayer);
        return Ok("matchups generated");
    }

    public class GenerateMatchupsRequest // if I ever need this elsewhere I'll have to move it
    {
        public int LeagueId { get; set; }
        public int TotalWeeks { get; set; }
        public int GamesPerPlayer { get; set; }
    }
}