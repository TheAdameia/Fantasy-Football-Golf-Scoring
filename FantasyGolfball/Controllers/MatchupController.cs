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


    [HttpGet("by-league")]
    [Authorize]
    public IActionResult GetByLeagueAndUser(int leagueId)
    {
        if (leagueId == 0)
        {
            return BadRequest();
        }

        var matchups = _dbContext.Matchups
            .Where(m => m.LeagueId == leagueId)
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
                            SeasonWeek = musp.Scoring.SeasonWeek,
                            Points = musp.Scoring.Points
                        },
                        Player = new PlayerFullExpandDTO
                        {
                            PlayerId = musp.Player.PlayerId,
                            PlayerFirstName = musp.Player.PlayerFirstName,
                            PlayerLastName = musp.Player.PlayerLastName,
                            PositionId = musp.Player.PositionId,
                            Position = new PositionDTO
                            {
                                PositionId = musp.Player.Position.PositionId,
                                PositionShort = musp.Player.Position.PositionShort,
                                PositionLong = musp.Player.Position.PositionLong
                            },
                            PlayerStatuses = musp.Player.PlayerStatuses.Select(ps => new PlayerStatusDTO
                            {
                                PlayerStatusId = ps.PlayerStatusId,
                                PlayerId = ps.PlayerId,
                                StatusId = ps.StatusId,
                                StatusStartWeek = ps.StatusStartWeek,
                                Status = new StatusDTO
                                {
                                    StatusId = ps.Status.StatusId,
                                    StatusType = ps.Status.StatusType,
                                    ViableToPlay = ps.Status.ViableToPlay,
                                    RequiresBackup = ps.Status.RequiresBackup
                                }
                            }).ToList(),
                            PlayerTeams = musp.Player.PlayerTeams.Select(pt => new PlayerTeamDTO
                            {
                                PlayerTeamId = pt.PlayerTeamId,
                                PlayerId = pt.PlayerId,
                                TeamStartWeek = pt.TeamStartWeek,
                                TeamId = pt.TeamId,
                                Team = new TeamDTO
                                {
                                    TeamId = pt.Team.TeamId,
                                    TeamName = pt.Team.TeamName,
                                    TeamCity = pt.Team.TeamCity,
                                    ByeWeek = pt.Team.ByeWeek,
                                    ActivePeriods = pt.Team.ActivePeriods.Select(ap => new ActivePeriodDTO
                                    {
                                        ActivePeriodId = ap.ActivePeriodId,
                                        Start = ap.Start,
                                        End = ap.End
                                    }).ToList()
                                }
                            }).ToList()
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