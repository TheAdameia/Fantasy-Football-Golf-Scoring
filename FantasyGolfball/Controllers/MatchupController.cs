using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class MatchupController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public MatchupController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetByLeague(int leagueId)
    {
        if (leagueId == 0)
        {
            return BadRequest();
        }

        List<Matchup> matchups = _dbContext.Matchups
            .Include(m => m.MatchupUsers)
            .Where(m => m.LeagueId == leagueId)
            .ToList();

        if (matchups == null)
        {
            return NotFound();
        }

        return Ok(matchups);
    }

    // [HttpPost]
    // // [Authorize]
    // public IActionResult Post(Matchup matchup)
    // {
    //     if (matchup == null)
    //     {
    //         return BadRequest();
    //     }
    //     _dbContext.Matchups.Add(matchup);
    //     _dbContext.SaveChanges();
    //     return Ok();
    // }
}