using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class RosterController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public RosterController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetByUserAndLeague(int userId, int leagueId)
    {
        return Ok(_dbContext.Rosters
        .Where(r => r.UserId == userId && r.LeagueId == leagueId)
        .ToList());
    }
}