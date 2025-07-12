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

public class DataImportController : ControllerBase
{
    private FantasyGolfballDbContext _dbContext;

    public DataImportController(FantasyGolfballDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Authorize]
    public IActionResult ImportData()
    {
        Console.WriteLine("Bubkis Galore!");
        return Ok();
    }
}
