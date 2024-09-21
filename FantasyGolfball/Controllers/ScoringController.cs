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
    public IActionResult Get()
    {
        return Ok(_dbContext.Scorings.ToList());
    }
}