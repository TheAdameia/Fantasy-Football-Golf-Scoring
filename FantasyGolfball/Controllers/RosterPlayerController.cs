using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class RosterPlayerController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public RosterPlayerController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetPlayersByRoster(int rosterId)
    {
        return Ok(_dbContext.RosterPlayers
        .Where(rp => rp.RosterId == rosterId)
        .Include(rp => rp.PlayerId)
        .ToList());
    }
}