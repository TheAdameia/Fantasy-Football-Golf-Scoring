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

    [HttpGet]
    [Authorize]
    public IActionResult GetAll()
    {
        return Ok(_dbContext.Scorings.ToList());
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

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Put(Scoring scoring)
    {
        Scoring scoreToUpdate = _dbContext.Scorings
        .SingleOrDefault(s => s.ScoringId == scoring.ScoringId);

        if (scoreToUpdate == null)
        {
            return NotFound();
        }

        scoreToUpdate.Points = scoring.Points;
        _dbContext.SaveChanges();
        return NoContent();
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