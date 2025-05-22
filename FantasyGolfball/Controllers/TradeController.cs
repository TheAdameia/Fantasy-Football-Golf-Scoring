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
        // checks begin
        if (tradePOSTDTO == null)
        {
            return BadRequest();
        }

        var FirstPartyRoster = _dbContext.Rosters
            .Include(r => r.RosterPlayers)
            .SingleOrDefault(r => r.RosterId == tradePOSTDTO.FirstPartyRosterId);

        if (FirstPartyRoster == null)
        {
            return BadRequest($"Error: FirstPartyRoster {tradePOSTDTO.FirstPartyRosterId} in Trade creation was null");
        }

        var SecondPartyRoster = _dbContext.Rosters
            .Include(r => r.RosterPlayers)
            .SingleOrDefault(r => r.RosterId == tradePOSTDTO.SecondPartyRosterId);

        if (SecondPartyRoster == null)
        {
            return BadRequest($"Error: SecondPartyRoster {tradePOSTDTO.SecondPartyRosterId} in Trade creation was null");
        }

        // checks end

        var tradePlayers = new List<TradePlayer>();

        foreach (var playerId in tradePOSTDTO.TradePieces)
        {
            var fromFirstParty = FirstPartyRoster.RosterPlayers.Any(rp => rp.PlayerId == playerId);
            var fromSecondParty = SecondPartyRoster.RosterPlayers.Any(rp => rp.PlayerId == playerId);

            if (!fromFirstParty && !fromSecondParty)
            {
                return BadRequest($"PlayerId {playerId} not found on Roster {FirstPartyRoster.RosterId} or Roster {SecondPartyRoster.RosterId}.");
            }

            var tradePlayer = new TradePlayer
            {
                PlayerId = playerId,
                GivingRosterId = fromFirstParty ? tradePOSTDTO.FirstPartyRosterId : tradePOSTDTO.SecondPartyRosterId,
                ReceivingRosterId = fromFirstParty ? tradePOSTDTO.SecondPartyRosterId : tradePOSTDTO.FirstPartyRosterId
            };

            tradePlayers.Add(tradePlayer);
        }


        var NewTrade = new Trade
        {
            LeagueId = tradePOSTDTO.LeagueId,
            FirstPartyRosterId = tradePOSTDTO.FirstPartyRosterId,
            SecondPartyRosterId = tradePOSTDTO.SecondPartyRosterId,
            FirstPartyAcceptance = true,
            SecondPartyAcceptance = false,
            TradeComplete = false,
            WeekActivation = tradePOSTDTO.WeekActivation, // I have to think about how I want to do this one
            TradePlayers = tradePlayers
        };

        _dbContext.Trades.Add(NewTrade);
        _dbContext.SaveChanges();

        return Ok();
    }
    
}