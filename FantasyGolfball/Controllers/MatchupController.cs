using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;

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

    // There is an interesting question of what GETs I will need here.
    // I'm not sure I'd ever need to delete or modify them either as a matter of normal operations.

    // [HttpPost]
    // // [Authorize]
    // public IActionResult Post(Matchup matchup)
    // {
    //     if (matchup == null)
    //     {
    //         return BadRequest();
    //     }
    //     _dbContext.Matchups.Add(matchup);
    //     _dbContext.SaveChanges();
    //     return Ok();
    // }
}