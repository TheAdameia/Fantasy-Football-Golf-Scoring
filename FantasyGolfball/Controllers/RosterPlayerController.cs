using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;

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

    [HttpPost]
    // [Authorize]
    public IActionResult Post(RosterPlayerPOSTDTO rosterPlayerPOSTDTO)
    {
        var rosterPlayer = new RosterPlayer
        {
            PlayerId = rosterPlayerPOSTDTO.PlayerId,
            RosterId = rosterPlayerPOSTDTO.RosterId,
            RosterPosition = rosterPlayerPOSTDTO.RosterPosition
        };
        
        _dbContext.RosterPlayers.Add(rosterPlayer);
        _dbContext.SaveChanges();

        return Ok();
    }
}