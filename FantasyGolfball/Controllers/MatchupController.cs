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
                    MatchupUserId = mu.MatchupUserId,
                    UserProfileId = mu.UserProfileId,
                    MatchupId = mu.MatchupId,
                    MatchupUserSavedPlayers = mu.MatchupUserSavedPlayers.Select(musp => new MatchupUserSavedPlayerDTO
                    {
                        MatchupUserSavedPlayerId = musp.MatchupUserSavedPlayerId,
                        MatchupUserId = musp.MatchupUserId,
                        PlayerId = musp.PlayerId,
                        ScoringId = musp.ScoringId,
                        RosterPlayerPosition = musp.RosterPlayerPosition,
                        Scoring = new ScoringDTO
                        {
                            ScoringId = musp.Scoring.ScoringId,
                            PlayerId = musp.Scoring.PlayerId,
                            SeasonYear = musp.Scoring.SeasonYear,
                            SeasonWeek = musp.Scoring.SeasonWeek,
                            Points = musp.Scoring.Points
                        },
                        Player = new PlayerFullExpandDTO
                        {
                            PlayerId = musp.Player.PlayerId,
                            PlayerFirstName = musp.Player.PlayerFirstName,
                            PlayerLastName = musp.Player.PlayerLastName,
                            PositionId = musp.Player.PositionId,
                            StatusId = musp.Player.StatusId,
                            Position = new PositionDTO
                            {
                                PositionId = musp.Player.Position.PositionId,
                                PositionShort = musp.Player.Position.PositionShort,
                                PositionLong = musp.Player.Position.PositionLong
                            },
                            Status = new StatusDTO
                            {
                                StatusId = musp.Player.Status.StatusId,
                                StatusType = musp.Player.Status.StatusType,
                                ViableToPlay = musp.Player.Status.ViableToPlay,
                                RequiresBackup = musp.Player.Status.RequiresBackup
                            }
                        }
                    }).ToList(),
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