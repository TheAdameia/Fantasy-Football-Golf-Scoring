using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class RosterController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public RosterController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetByUserAndLeague(int userId, int leagueId)
    {
        if (userId == 0 || leagueId == 0)
        {
            return BadRequest("One or both IDs are 0");
        }

        Roster roster = _dbContext.Rosters
            .Include(r => r.RosterPlayers)
                .ThenInclude(rp => rp.Player)
            .SingleOrDefault(r => r.UserId == userId && r.LeagueId == leagueId);

        if (roster == null)
        {
            return NotFound();
        }

        RosterFullExpandDTO rosterFullExpand = new RosterFullExpandDTO
        {
            RosterId = roster.RosterId,
            LeagueId = roster.LeagueId,
            RosterPlayers = roster.RosterPlayers.Select(rp => new RosterPlayerFullExpandDTO
            {
                RosterPlayerId = rp.RosterPlayerId,
                PlayerId = rp.PlayerId,
                RosterId = rp.RosterId,
                Player = new PlayerFullExpandDTO
                {
                    PlayerId = rp.Player.PlayerId,
                    PlayerFirstName = rp.Player.PlayerFirstName,
                    PlayerLastName = rp.Player.PlayerLastName,
                    StatusId = rp.Player.StatusId,
                    PositionId = rp.Player.PositionId
                }
            }).ToList()
        };
    }

    [HttpPost]
    // [Authorize]
    public IActionResult Post(Roster roster)
    {
        _dbContext.Rosters.Add(roster);
        _dbContext.SaveChanges();

        return Created($"api/rosters/{roster.RosterId}", roster);
    }

    // The PUT for rosters is going to have to be similar to my items PUT from my warehouse project.
}