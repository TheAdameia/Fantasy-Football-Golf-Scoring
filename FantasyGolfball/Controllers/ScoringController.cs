using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;

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
    // [Authorize]
    public IActionResult GetAll()
    {
        return Ok(_dbContext.Scorings.ToList());
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetOne(int id)
    {
        return Ok(_dbContext.Scorings
        .SingleOrDefault(s => s.ScoringId == id));
    }

    [HttpPost]
    // [Authorize]
    public IActionResult Post(Scoring scoring)
    {
        _dbContext.Scorings.Add(scoring);
        _dbContext.SaveChanges();

        return Created($"api/scoring/{scoring.ScoringId}", scoring);
    }
}