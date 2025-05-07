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
                },
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