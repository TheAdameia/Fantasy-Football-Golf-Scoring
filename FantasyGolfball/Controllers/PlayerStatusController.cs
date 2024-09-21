using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class PlayerStatusController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public PlayerStatusController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetPlayerStatusByPlayer(int playerId)
    {
        return Ok(_dbContext.PlayerStatuses
        .Where(ps => ps.PlayerId == playerId)
        .ToList());
    }

    [HttpPost]
    // [Authorize]
    public IActionResult Post(PlayerStatus playerStatus)
    {
        _dbContext.PlayerStatuses.Add(playerStatus);
        _dbContext.SaveChanges();

        return Created(playerStatus)
    }
}