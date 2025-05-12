using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;
using System.Transactions;

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
    [Authorize]
    public IActionResult GetAll()
    {
        return Ok(_dbContext.Leagues
        .Include(l => l.LeagueUsers));
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post(LeaguePOSTDTO leaguePOSTDTO)
    {
        // checks begin here
        if (!ModelState.IsValid)
        {
            return BadRequest($"model invalid: {ModelState}");
        }

        if (string.IsNullOrWhiteSpace(leaguePOSTDTO.LeagueName) || leaguePOSTDTO.LeagueName.Length > 100)
        {
            return BadRequest("League name is required and must be less than 100 characters.");
        }

        if (!Enum.TryParse<AdvancementType>(leaguePOSTDTO.Advancement, true, out var advancement)) // true makes it case-insensitive 
        {
            return BadRequest("Invalid advancement type.");
        }

        if (leaguePOSTDTO.PlayerLimit < 2 || leaguePOSTDTO.PlayerLimit > 8)
        {
            return BadRequest("Player limit must be between 2 and 8.");
        }

        if (leaguePOSTDTO.SeasonStartDate < DateTime.UtcNow.AddDays(-1))
        {
            return BadRequest("Season start date must be in the future.");
        }

        leaguePOSTDTO.LeagueName = System.Text.RegularExpressions.Regex.Replace(
            leaguePOSTDTO.LeagueName, "<.*?>", string.Empty
        );
        // checks end here

        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var season = _dbContext.Seasons.SingleOrDefault(s => s.SeasonYear == leaguePOSTDTO.SeasonYear);

            if (season == null)
            {
                return BadRequest($"No Season found for {leaguePOSTDTO.SeasonYear}");
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
                IsLeagueFinished =  false,
                DraftStartTime = leaguePOSTDTO.DraftStartTime.ToUniversalTime(),
                JoinPassword = leaguePOSTDTO.JoinPassword,
                RequiresPassword = leaguePOSTDTO.RequiresPassword,
                SeasonStartDate = leaguePOSTDTO.SeasonStartDate.ToUniversalTime(),
                Advancement = advancement
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
                
                
            }

            _dbContext.SaveChanges();
            transaction.Commit();
            return Created($"api/leagues/{league.LeagueId}", league);
        }
        catch(Exception ex)
        {
            // this only rolls back a few of the changes, but I can write error handling to delete vestiges if they are created
            transaction.Rollback();
            return StatusCode(500, $"An error occurred while trying to create a League: {ex.Message}");
        }
    }

    [HttpPut("join-league")]
    [Authorize]
    public IActionResult JoinLeague(int leagueId, int userId, string? passwordInput)
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

        if (league.RequiresPassword)
        {
            if (league.JoinPassword != passwordInput)
            {
                return BadRequest("Wrong password entered");
            }
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
    [Authorize]
    public IActionResult GetByUser(int userId)
    {
        var UserLeagues = _dbContext.Leagues
        .Where(l => l.LeagueUsers.Any(lu => lu.UserProfileId == userId))
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
            DraftStartTime = l.DraftStartTime,
            SeasonStartDate = l.SeasonStartDate,
            Advancement = l.Advancement,
            Season = new SeasonDTO
            {
                SeasonId = l.Season.SeasonId,
                SeasonYear = l.Season.SeasonYear
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
                Roster = new RosterFullExpandDTO //these are used in the current Matchup for opps and I'm not sure if anywhere else
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
                            PlayerStatuses = rp.Player.PlayerStatuses
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
                            Position = new PositionDTO
                            {
                                PositionId = rp.Player.Position.PositionId,
                                PositionShort = rp.Player.Position.PositionShort,
                                PositionLong = rp.Player.Position.PositionLong
                            },
                            PlayerTeams = rp.Player.PlayerTeams.Select(pt => new PlayerTeamDTO
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
                }
            }).ToList()
        }).ToList();

        return Ok(UserLeagues);
                        
    }

    [HttpGet("not-full-leagues")]
    [Authorize]
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
                RequiresPassword = l.RequiresPassword,
                SeasonStartDate = l.SeasonStartDate,
                Advancement = l.Advancement,
                Season = new SeasonDTO
                {
                    SeasonId = l.Season.SeasonId,
                    SeasonYear = l.Season.SeasonYear
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