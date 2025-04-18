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
    [Authorize]
    public IActionResult GetPlayersByRoster(int rosterId)
    {
        return Ok(_dbContext.RosterPlayers
        .Where(rp => rp.RosterId == rosterId)
        .Include(rp => rp.PlayerId)
        .ToList());
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post(RosterPlayerPOSTDTO rosterPlayerPOSTDTO)
    {
        // checks begin here
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var roster = _dbContext.Rosters
            .Where(r => r.RosterId == rosterPlayerPOSTDTO.RosterId)
            .SingleOrDefault();
        
        if (roster == null) {
            return BadRequest($"No roster found for RosterId{rosterPlayerPOSTDTO.RosterId}");
        }

        var league = _dbContext.Leagues
            .Where(l => l.LeagueId == roster.LeagueId)
            .SingleOrDefault();

        if (league == null) {
            return BadRequest($"No League found for LeagueId{roster.LeagueId}");
        }

        if (roster.RosterPlayers.Count() >= league.MaxRosterSize) {
            return BadRequest($"Request would exceed maximum roster size of {league.MaxRosterSize}");
        }

        if (roster.RosterPlayers.Any(rp => rp.PlayerId == rosterPlayerPOSTDTO.PlayerId))
        {
            return BadRequest($"Roster {roster.RosterId} already contains player {rosterPlayerPOSTDTO.PlayerId}.");
        }
        // checks end here

        var rosterPlayer = new RosterPlayer
        {
            PlayerId = rosterPlayerPOSTDTO.PlayerId,
            RosterId = rosterPlayerPOSTDTO.RosterId,
            RosterPosition = "bench"
        };
        
        _dbContext.RosterPlayers.Add(rosterPlayer);
        _dbContext.SaveChanges();

        return Ok();
    }

    [HttpDelete("{rosterPlayerId}")]
    [Authorize]
    public IActionResult Delete(int rosterPlayerId)
    {
        RosterPlayer rosterPlayerToDelete = _dbContext.RosterPlayers.SingleOrDefault(rp => rp.RosterPlayerId == rosterPlayerId);
        
        if (rosterPlayerToDelete == null)
        {
            return NotFound();
        }
        _dbContext.RosterPlayers.Remove(rosterPlayerToDelete);
        _dbContext.SaveChanges();
        
        return NoContent();
    }

    [HttpPut("roster-position")]
    [Authorize]
    public IActionResult SetRosterPosition(int rosterPlayerId, string position)
    {
        RosterPlayer rosterPlayer = _dbContext.RosterPlayers.SingleOrDefault(rp => rp.RosterPlayerId == rosterPlayerId);

        if (rosterPlayer == null)
        {
            return NotFound();
        }

        Roster roster = _dbContext.Rosters.SingleOrDefault(r => r.RosterPlayers.Contains(rosterPlayer));

        if (roster == null)
        {
            return NotFound("No Roster found for RosterPlayer");
        }

        if (position == "bench")
        {
            rosterPlayer.RosterPosition = "bench";
            _dbContext.SaveChanges();
            return NoContent();
        }

        if ( !roster.RosterPlayers.Any(rp => rp.RosterPosition == position))
        {
            rosterPlayer.RosterPosition = position;
            _dbContext.SaveChanges();
            return NoContent();
        } else
        {
            return BadRequest("A player already has that role");
        }
    }
}