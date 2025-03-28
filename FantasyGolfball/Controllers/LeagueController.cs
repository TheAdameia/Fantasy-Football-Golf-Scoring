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
        using var transaction = _dbContext.Database.BeginTransaction();

        try
        {
            Season season;

            if (!leaguePOSTDTO.RealSeason)
            {
                season = new Season
                {
                    RealSeason = leaguePOSTDTO.RealSeason,
                    SeasonYear = leaguePOSTDTO.SeasonYear,
                    SeasonStartDate = leaguePOSTDTO.SeasonStartDate,
                    Advancement = Enum.Parse<AdvancementType>(leaguePOSTDTO.Advancement, true) // true makes it case-insensitive                
                };

                _dbContext.Seasons.Add(season);
                _dbContext.SaveChanges();
            }
            else
            {
                // finds the real season
                season = _dbContext.Seasons.FirstOrDefault(s => s.SeasonYear == leaguePOSTDTO.SeasonYear && s.RealSeason);

                if (season == null)
                {
                    return BadRequest($"No real season found for year {leaguePOSTDTO.SeasonYear}");
                }
            }

            var league = new League
            {
                PlayerLimit = leaguePOSTDTO.PlayerLimit,
                RandomizedDraftOrder = leaguePOSTDTO.RandomizedDraftOrder,
                UsersVetoTrades = leaguePOSTDTO.UsersVetoTrades,
                LeagueName = leaguePOSTDTO.LeagueName,
                RequiredFullToStart = leaguePOSTDTO.RequiredFullToStart,
                MaxRosterSize = leaguePOSTDTO.MaxRosterSize,
                IsDraftComplete = false,
                SeasonId = season.SeasonId,
                IsLeagueFinished =  false
            };
            
            _dbContext.Leagues.Add(league);
            _dbContext.SaveChanges();

            var user = _dbContext.UserProfiles.SingleOrDefault(up => leaguePOSTDTO.CreatorId == up.Id);
            if (user != null)
            {
                var roster = new Roster
                {
                    LeagueId = league.LeagueId,
                    UserId = user.Id
                };
                _dbContext.Rosters.Add(roster);
                _dbContext.SaveChanges();

                var leagueUser = new LeagueUser
                {
                    UserProfileId = user.Id,
                    LeagueId = league.LeagueId,
                    RosterId = roster.RosterId
                };
                _dbContext.LeagueUsers.Add(leagueUser);
                _dbContext.SaveChanges();
                
            }
            
            return Created($"api/leagues/{league.LeagueId}", league);
        }
        catch(Exception ex)
        {
            // rollback the db changes if an error occurs
            transaction.Rollback();
            return StatusCode(500, $"An error occurred while trying to create a League: {ex.Message}");
        }
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
            .Include(l => l.LeagueUsers)
            .SingleOrDefault(l => l.LeagueId == leagueId);
        UserProfile user = _dbContext.UserProfiles.SingleOrDefault(u => u.Id == userId);

        if (league == null || user == null)
        {
            return BadRequest("no league found or no user found");
        }

        if ((league.LeagueUsers.Count() + 1) > league.PlayerLimit)
        {
            return BadRequest("League is full!");
        }

        if (league.LeagueUsers.Any(lu => lu.UserProfileId == user.Id))
        {
            return BadRequest("User already joined league");
        }

        var roster = new Roster
        {
            LeagueId = league.LeagueId,
            UserId = user.Id
        };
        _dbContext.Rosters.Add(roster);
        _dbContext.SaveChanges();

        var leagueUser = new LeagueUser
        {
            UserProfileId = user.Id,
            League = league,
            RosterId = roster.RosterId
        };
        _dbContext.LeagueUsers.Add(leagueUser);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpGet("by-user/{userId}")]
    // [Authorize]
    public IActionResult GetByUser(int userId)
    {
        var UserLeagues = _dbContext.Leagues
        .Where(l => l.LeagueUsers.Any(lu => lu.UserProfileId == userId))
        .Include(l => l.Season)
        .Include(l => l.LeagueUsers)
            .ThenInclude(lu => lu.UserProfile)
                .ThenInclude(up => up.IdentityUser)
        .Include(l => l.LeagueUsers)
            .ThenInclude(lu => lu.Roster)
                .ThenInclude(r => r.RosterPlayers)
                    .ThenInclude(rp => rp.Player)
                        .ThenInclude(p => p.Status)
        .Include(l => l.LeagueUsers)
            .ThenInclude(lu => lu.Roster)
                .ThenInclude(r => r.RosterPlayers)
                    .ThenInclude(rp => rp.Player)
                        .ThenInclude(p => p.Position)
        .Select(l => new LeagueFullExpandDTO
        {
            LeagueId = l.LeagueId,
            PlayerLimit = l.PlayerLimit,
            RandomizedDraftOrder = l.RandomizedDraftOrder,
            UsersVetoTrades = l.UsersVetoTrades,
            LeagueName = l.LeagueName,
            RequiredFullToStart = l.RequiredFullToStart,
            MaxRosterSize = l.MaxRosterSize,
            IsDraftComplete = l.IsDraftComplete,
            IsLeagueFinished = l.IsLeagueFinished,
            SeasonId = l.SeasonId,
            Season = new SeasonDTO
            {
                SeasonId = l.Season.SeasonId,
                SeasonYear = l.Season.SeasonYear,
                SeasonStartDate = l.Season.SeasonStartDate,
                RealSeason = l.Season.RealSeason
            },
            LeagueUsers = l.LeagueUsers.Select(lu => new LeagueUserFullExpandDTO
            {
                LeagueUserId = lu.LeagueUserId,
                LeagueId = lu.LeagueId,
                UserProfileId = lu.UserProfileId,
                RosterId = lu.RosterId,
                UserProfile = new UserProfileSafeExportDTO
                {
                    Id = lu.UserProfile.Id,
                    UserName = lu.UserProfile.IdentityUser.UserName
                },
                Roster = new RosterFullExpandDTO
                {
                    RosterId = lu.RosterId,
                    LeagueId = lu.LeagueId,
                    RosterPlayers = lu.Roster.RosterPlayers.Select(rp => new RosterPlayerFullExpandDTO
                    {
                        RosterPlayerId = rp.RosterPlayerId,
                        PlayerId = rp.PlayerId,
                        RosterPosition = rp.RosterPosition,
                        RosterId = rp.RosterId,
                        Player = new PlayerFullExpandDTO
                        {
                            PlayerId = rp.Player.PlayerId,
                            PlayerFirstName = rp.Player.PlayerFirstName,
                            PlayerLastName = rp.Player.PlayerLastName,
                            PositionId = rp.Player.PositionId,
                            StatusId = rp.Player.StatusId,
                            Status = new StatusDTO
                            {
                                StatusId = rp.Player.Status.StatusId,
                                StatusType = rp.Player.Status.StatusType,
                                ViableToPlay = rp.Player.Status.ViableToPlay,
                                RequiresBackup = rp.Player.Status.RequiresBackup
                            },
                            Position = new PositionDTO
                            {
                                PositionId = rp.Player.Position.PositionId,
                                PositionShort = rp.Player.Position.PositionShort,
                                PositionLong = rp.Player.Position.PositionLong
                            }
                        }
                    }).ToList()
                }
            }).ToList()
        }).ToList();

        return Ok(UserLeagues);
                        
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
                SeasonId = l.SeasonId,
                Season = new SeasonDTO
                {
                    SeasonId = l.Season.SeasonId,
                    SeasonYear = l.Season.SeasonYear,
                    SeasonStartDate = l.Season.SeasonStartDate,
                    RealSeason = l.Season.RealSeason
                },
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