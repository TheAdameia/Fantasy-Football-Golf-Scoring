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
        // .Include(r => ) I need to make a DTO for this because a roster doesn't contain a list
        .ToList());
    }

    [HttpPost]
    // [Authorize]
    public IActionResult Post(Roster roster)
    {
        _dbContext.Rosters.Add(roster);
        _dbContext.SaveChanges();

        return Created($"api/rosters/{roster.RosterId}", roster);
    }

    // The PUT for rosters is going to have to be similar to my items PUT from my warehouse project.
}