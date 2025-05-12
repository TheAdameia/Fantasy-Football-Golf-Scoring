using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;


namespace FantasyGolfball.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HistoricalController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public HistoricalController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("HistoricalDraftState")]
    [Authorize]
    public IActionResult GetHistoricalDraftStateByLeague(int leagueId)
    {
        if (leagueId <= 0)
        {
            return BadRequest();
        }

        var historicalDraftState = _dbContext.HistoricalDraftStates
            .Select(hds => new HistoricalDraftStateDTO
            {
                HistoricalDraftStateId = hds.HistoricalDraftStateId,
                LeagueId = hds.LeagueId,
                PermanentDraftOrder = hds.PermanentDraftOrder,
                UserRosters = hds.UserRosters
            })
            .SingleOrDefault(hsd => hsd.LeagueId == leagueId);

        if (historicalDraftState == null)
        {
            return BadRequest($"No saved DraftState found for League {leagueId}");
        }

        return Ok(historicalDraftState);
    }
}