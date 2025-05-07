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
    [Authorize]
    public IActionResult GetByUserAndLeague(int userId, int leagueId)
    {
        if (userId == 0 || leagueId == 0)
        {
            return BadRequest("One or both IDs are 0");
        }

        Roster roster = _dbContext.Rosters
            .Include(r => r.RosterPlayers)
                .ThenInclude(rp => rp.Player)
                    .ThenInclude(p => p.Position)
            .Include(r => r.RosterPlayers)
                .ThenInclude(rp => rp.Player)
                    .ThenInclude(p => p.Status)
            .Include(r => r.RosterPlayers)
                    .ThenInclude(rp => rp.Player)
                        .ThenInclude(p => p.PlayerTeams)
                            .ThenInclude(pt => pt.Team)
                                .ThenInclude(t => t.ActivePeriods)
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
                RosterPosition = rp.RosterPosition,
                Player = new PlayerFullExpandDTO
                {
                    PlayerId = rp.Player.PlayerId,
                    PlayerFirstName = rp.Player.PlayerFirstName,
                    PlayerLastName = rp.Player.PlayerLastName,
                    StatusId = rp.Player.StatusId,
                    PositionId = rp.Player.PositionId,
                    Position = new PositionDTO
                    {
                        PositionId = rp.Player.Position.PositionId,
                        PositionShort = rp.Player.Position.PositionShort,
                        PositionLong = rp.Player.Position.PositionLong
                    },
                    Status = new StatusDTO
                    {
                        StatusId = rp.Player.Status.StatusId,
                        StatusType = rp.Player.Status.StatusType,
                        ViableToPlay = rp.Player.Status.ViableToPlay,
                        RequiresBackup = rp.Player.Status.RequiresBackup
                    },
                    PlayerTeams = rp.Player.PlayerTeams
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
                    }).ToList()
                }
            }).ToList()
        };

        return Ok(rosterFullExpand);
    }
}