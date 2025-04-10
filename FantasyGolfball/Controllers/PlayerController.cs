using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class PlayerController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public PlayerController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllPlayers()
    {
        var AllPlayers = _dbContext.Players
            .Include(p => p.Status)
            .Include(p => p.Position)
            .Select(p => new PlayerFullExpandDTO
            {
                PlayerId = p.PlayerId,
                PlayerFirstName = p.PlayerFirstName,
                PlayerLastName = p.PlayerLastName,
                StatusId = p.StatusId,
                PositionId = p.PositionId,
                Position = new PositionDTO
                {
                    PositionId = p.Position.PositionId,
                    PositionShort = p.Position.PositionShort,
                    PositionLong = p.Position.PositionLong
                },
                Status = new StatusDTO
                {
                    StatusId = p.Status.StatusId,
                    StatusType = p.Status.StatusType,
                    ViableToPlay = p.Status.ViableToPlay,
                    RequiresBackup = p.Status.RequiresBackup
                }
            })
            .ToList();

        return Ok(AllPlayers);
    }
}