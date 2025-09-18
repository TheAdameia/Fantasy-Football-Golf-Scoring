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

    [HttpGet("by-league")]
    [Authorize]
    public IActionResult GetAllPlayers(int leagueId)
    {
        League league = _dbContext.Leagues.SingleOrDefault(l => l.LeagueId == leagueId);
        
        if (league == null)
        {
            return BadRequest($"League {leagueId} not found in Players request");
        }

        int LeagueWeekValue = 1;

        if (league.CurrentWeek > 1)
        {
            LeagueWeekValue = (int)league.CurrentWeek;
        }

        var AllPlayers = _dbContext.Players
            .Where(p => p.SeasonId == league.SeasonId)
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
                PlayerStatuses = p.PlayerStatuses
                    .Where(ps => ps.StatusStartWeek <= LeagueWeekValue)
                    .OrderByDescending(ps => ps.StatusStartWeek)
                    .Take(1)
                    .Select(ps => new PlayerStatusDTO
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
                    .Where(pt => pt.TeamStartWeek <= LeagueWeekValue)
                    .OrderByDescending(pt => pt.TeamStartWeek)
                    .Take(1)                 
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
                            Abbreviation = pt.Team.Abbreviation
                        }
                    })
                    .ToList()
            })
            .ToList();

        return Ok(AllPlayers);
    }
}