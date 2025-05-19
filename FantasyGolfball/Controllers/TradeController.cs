using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Models.DTOs;

namespace FantasyGolfball.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradeController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;
    public TradeController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Authorize]
    public IActionResult PostTradeOffer(TradePOSTDTO tradePOSTDTO)
    {
        if (tradePOSTDTO == null)
        {
            return BadRequest();
        }


    }
    

    
}