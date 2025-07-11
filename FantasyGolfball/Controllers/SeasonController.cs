using FantasyGolfball.Data;
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

    [HttpGet]
    [Authorize]
    public IActionResult GetAll() // unused currently but can integrate with LeagueForm
    {
        return Ok(_dbContext.Seasons);
    }
}