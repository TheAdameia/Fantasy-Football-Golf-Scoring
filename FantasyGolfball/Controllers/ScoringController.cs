using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ScoringController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public ScoringController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("by-season")]
    [Authorize]
    public IActionResult GetAll(int seasonId)
    {
        return Ok(_dbContext.Scorings
            .Where(s => s.SeasonId == seasonId)
            .ToList()
        );
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetOne(int id)
    {
        return Ok(_dbContext.Scorings
        .SingleOrDefault(s => s.ScoringId == id));
    }

    [HttpGet("by-player")]
    [Authorize]
    public IActionResult GetByPlayer(int playerId)
    {
        return Ok(_dbContext.Scorings.Where(s => s.PlayerId == playerId).ToList());
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post(Scoring scoring)
    {
        _dbContext.Scorings.Add(scoring);
        _dbContext.SaveChanges();

        return Created($"api/scoring/{scoring.ScoringId}", scoring);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        Scoring scoreToDelete = _dbContext.Scorings.SingleOrDefault(s => s.ScoringId == id);
        if (scoreToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Scorings.Remove(scoreToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }
}