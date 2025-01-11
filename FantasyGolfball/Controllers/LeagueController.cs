using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;

namespace FantasyGolfball.Controllers;
[ApiController]
[Route("api/[controller]")]

public class LeagueController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public LeagueController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAll()
    {
        return Ok(_dbContext.Leagues
        .Include(l => l.LeagueUsers));
    }

    [HttpPost]
    // [Authorize]
    public IActionResult Post(LeaguePOSTDTO leaguePOSTDTO)
    {
        var league = new League
        {
            PlayerLimit = leaguePOSTDTO.PlayerLimit,
            RandomizedDraftOrder = leaguePOSTDTO.RandomizedDraftOrder,
            UsersVetoTrades = leaguePOSTDTO.UsersVetoTrades,
            LeagueName = leaguePOSTDTO.LeagueName,
            RequiredFullToStart = leaguePOSTDTO.RequiredFullToStart,

        };

        var user = _dbContext.UserProfiles.SingleOrDefault(up => leaguePOSTDTO.CreatorId == up.Id);
        if (user != null)
        {
            var leagueUser = new LeagueUser
            {
                UserProfileId = user.Id,
                League = league
            };
            league.LeagueUsers = new List<LeagueUser> { leagueUser };

            var roster = new Roster
            {
                LeagueId = league.LeagueId,
                UserId = user.Id
            };
            _dbContext.Rosters.Add(roster);
        }
        
        _dbContext.Leagues.Add(league);
        _dbContext.SaveChanges();
        return Created($"api/leagues/{league.LeagueId}", league);
    }

    [HttpPut("join-league")]
    // [Authorize]
    public IActionResult JoinLeague(int leagueId, int userId)
    {
        if (leagueId == 0 || userId == 0)
        {
            return BadRequest("Bad IDs");
        }

        League league = _dbContext.Leagues
        .SingleOrDefault(l => l.LeagueId == leagueId);

        UserProfile user = _dbContext.UserProfiles
        .SingleOrDefault(u => u.Id == userId);

        if (league == null || user == null)
        {
            return BadRequest("no league found or no user found");
        }

        var leagueUser = new LeagueUser
        {
            UserProfileId = user.Id,
            League = league
        };
        
        var roster = new Roster
        {
            LeagueId = league.LeagueId,
            UserId = user.Id
        };

        _dbContext.Rosters.Add(roster);
        _dbContext.LeagueUsers.Add(leagueUser);
        _dbContext.SaveChanges();
        return NoContent();
    }

    // [HttpGet] // needs to also have distinct route
    // // [Authorize]
    // public IActionResult GetByUser(int userId)
    // {
    //     // return Ok(_dbContext.Leagues
    //     // .Where(l => l.))
    //     // expand it to solve it?
    // }

    [HttpGet("{leagueId}")]
    // [Authorize]
    public IActionResult GetByLeagueId(int leagueId)
    {
        return Ok(_dbContext.Leagues
        .SingleOrDefault(l => l.LeagueId == leagueId));
    }

    [HttpGet("not-full-leagues")]
    // [Authorize]
    public IActionResult GetNotFullLeagues()
    {
        var NotFullLeagues = _dbContext.Leagues
            .Include(l => l.LeagueUsers)
                .ThenInclude(lu => lu.UserProfile)
                    .ThenInclude(up => up.IdentityUser)
            .Where(l => l.LeagueUsers.Count < l.PlayerLimit)
            .Select(l => new LeagueSafeExportDTO
            {
                LeagueId = l.LeagueId,
                PlayerLimit = l.PlayerLimit,
                RandomizedDraftOrder = l.RandomizedDraftOrder,
                UsersVetoTrades = l.UsersVetoTrades,
                LeagueName = l.LeagueName,
                RequiredFullToStart = l.RequiredFullToStart,
                LeagueUsers = l.LeagueUsers.Select(lu => new LeagueUserSafeExportDTO
                {
                    LeagueUserId = lu.LeagueUserId,
                    LeagueId = lu.LeagueId,
                    UserProfileId = lu.UserProfileId,
                    UserProfile = new UserProfileSafeExportDTO
                    {
                        Id = lu.UserProfile.Id,
                        UserName = lu.UserProfile.IdentityUser.UserName
                    }
                }).ToList()
            })
            .ToList();
        
        return Ok(NotFullLeagues);
    }
}