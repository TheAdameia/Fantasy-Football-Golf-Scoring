using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyGolfball.Data;
using FantasyGolfball.Models;
using FantasyGolfball.Services;

namespace FantasyGolfball.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DataImportController : ControllerBase
{
    private readonly FantasyGolfballDbContext _dbContext;
    private readonly IPlayerImportService _playerImportService;
    private readonly IScoringImportService _scoringImportService;

    public DataImportController(FantasyGolfballDbContext context,
                                IPlayerImportService playerImportService,
                                IScoringImportService scoringImportService)
    {
        _dbContext = context;
        _playerImportService = playerImportService;
        _scoringImportService = scoringImportService;
    }

    [HttpPost("players")]
    [Authorize]
    public async Task<IActionResult> ImportPlayers(IFormFile file, [FromQuery] int seasonId, CancellationToken cancellationToken)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is empty or missing.");
        }

        try
        {
            var importCount = await _playerImportService.ImportPlayersFromCsvAsync(file.OpenReadStream(), seasonId, cancellationToken);
            return Ok(new { Message = $"Successfully imported {importCount} players." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Import failed: {ex.Message}");
        }
    }

    [HttpPost("scoring")]
    [Authorize]
    public async Task<IActionResult> ImportScoring(IFormFile file, [FromQuery] int seasonId, CancellationToken cancellationToken)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is empty or missing.");
        }

        try
        {
            var importCount = await _scoringImportService.ImportScoringFromCsvAsync(file.OpenReadStream(), seasonId, cancellationToken);
            return Ok(new { Message = $"Successfully imported {importCount} scores" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Import failed: {ex.Message}");
        }
    }
}
