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

    [HttpGet("by-season")]
    [Authorize]
    public IActionResult GetAllPlayers(int seasonId)
    {
        var AllPlayers = _dbContext.Players
            .Where(p => p.SeasonId == seasonId)
            .Select(p => new PlayerFullExpandDTO
            {
                PlayerId = p.PlayerId,
                PlayerFirstName = p.PlayerFirstName,
                PlayerLastName = p.PlayerLastName,
                PositionId = p.PositionId,
                Position = new PositionDTO
                {
                    PositionId = p.Position.PositionId,
                    PositionShort = p.Position.PositionShort,
                    PositionLong = p.Position.PositionLong
                },
                PlayerStatuses = p.PlayerStatuses.Select(ps => new PlayerStatusDTO
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
                PlayerTeams = p.PlayerTeams
                .OrderByDescending(pt => pt.TeamStartWeek) // how about... get Season, filter by closest to currentWeek. Would require some changes to what this endpoint needs
                .Select(pt => new PlayerTeamDTO
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
                })
                .Take(1)
                .ToList()
            })
            .ToList();

        return Ok(AllPlayers);
    }
}