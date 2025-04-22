using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class MatchupController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public MatchupController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    // [HttpGet]
    // [Authorize]
    // public IActionResult GetByLeague(int leagueId)
    // {
    //     if (leagueId == 0)
    //     {
    //         return BadRequest();
    //     }

    //     List<Matchup> matchups = _dbContext.Matchups
    //         .Include(m => m.MatchupUsers)
    //         .Where(m => m.LeagueId == leagueId)
    //         .ToList();

    //     if (matchups == null)
    //     {
    //         return NotFound();
    //     }

    //     return Ok(matchups);
    // }

    [HttpGet("by-league-and-user")]
    [Authorize]
    public IActionResult GetByLeagueAndUser(int leagueId, int userId)
    {
        if (leagueId == 0 || userId == 0)
        {
            return BadRequest();
        }

        var matchups = _dbContext.Matchups
            .Include(m => m.MatchupUsers)
                .ThenInclude(mu => mu.userProfile)
                    .ThenInclude(up => up.IdentityUser)
            .Where(m => m.LeagueId == leagueId)
            .Where(m => m.MatchupUsers.Any(mu => mu.UserProfileId == userId))
            .Select(m => new MatchupDTO
            {
                MatchupId = m.MatchupId,
                LeagueId = m.LeagueId,
                WeekId = m.WeekId,
                WinnerId = m.WinnerId,
                MatchupUsers = m.MatchupUsers.Select(mu => new MatchupUserDTO
                {
                    MatchupUserId = mu.MatchupId,
                    UserProfileId = mu.UserProfileId,
                    MatchupId = mu.MatchupId,
                    UserProfileDTO = new UserProfileSafeExportDTO
                    {
                        Id = mu.userProfile.Id,
                        UserName = mu.userProfile.IdentityUser.UserName
                    }
                }).ToList()
            }).ToList();

        if (matchups == null)
        {
            return BadRequest("No matchups found");
        }

        return Ok(matchups);
    }
}