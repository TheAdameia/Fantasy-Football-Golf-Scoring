using FantasyGolfball.Data;
using FantasyGolfball.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGolfball.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SeasonController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public SeasonController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("all-seasons")]
    [Authorize]
    public IActionResult GetAll()
    {
        return Ok(_dbContext.Seasons);
    }

    [HttpPost("post-season")]
    [Authorize(Roles = "Admin")]
    public IActionResult PostNewSeason(int seasonYear, int seasonWeeks)
    {
        if (seasonYear > 2050 || seasonYear < 1970)
        {
            return BadRequest($"Invalid seasonYear: {seasonYear}");
        }

        if (seasonWeeks > 18 || seasonWeeks < 4)
        {
            return BadRequest($"Invalid seasonWeeks: {seasonWeeks}");
        }

        if (_dbContext.Seasons.Any(s => s.SeasonYear == seasonYear))
        {
            return BadRequest($"Season already exists for year {seasonYear}");
        }

        var season = new Season
        {
            SeasonYear = seasonYear,
            SeasonWeeks = seasonWeeks
        };

        _dbContext.Add(season);
        _dbContext.SaveChanges();
        return Ok();

    }
}