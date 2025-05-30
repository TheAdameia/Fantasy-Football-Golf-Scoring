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

        var league = _dbContext.Leagues.SingleOrDefault(l => l.LeagueId == tradePOSTDTO.LeagueId);
        int TradeWeek = 0;

        if (league == null)
        {
            return BadRequest($"Error: League {tradePOSTDTO.LeagueId} not found for trade creation.");
        }

        if (league.CurrentWeek == null)
        {
            TradeWeek = 2;
        }
        else
        {
            TradeWeek = (int)league.CurrentWeek;
        }

        var activeTrades = _dbContext.Trades
            .Include(t => t.TradePlayers)
            .Where(t => t.LeagueId == league.LeagueId)
            .Where(t => t.TradeComplete == false)
            .ToList();

        var offeredPlayerIds = tradePOSTDTO.FirstPartyOffering
            .Concat(tradePOSTDTO.SecondPartyOffering)
            .ToHashSet(); // faster lookup (or so I'm told)
        
        var conflictingPlayers = activeTrades
            .SelectMany(t => t.TradePlayers)
            .Where(tp => offeredPlayerIds.Contains(tp.PlayerId))
            .Select(tp => tp.PlayerId)
            .Distinct()
            .ToList();

        if (conflictingPlayers.Any())
        {
            var conflictedIds = string.Join(", ", conflictingPlayers);
            return BadRequest($"Trade offer includes players already involved in an active trade: {conflictedIds}");
        }


        // checks end

        var tradePlayers = new List<TradePlayer>();

        foreach (var playerId in tradePOSTDTO.FirstPartyOffering)
        {
            var playerExists = FirstPartyRoster.RosterPlayers.Any(rp => rp.PlayerId == playerId);
            if (!playerExists)
            {
                return BadRequest($"PlayerId {playerId} is not on Roster {FirstPartyRoster.RosterId}.");
            }

            var tradePlayer = new TradePlayer
            {
                PlayerId = playerId,
                GivingRosterId = tradePOSTDTO.FirstPartyRosterId,
                ReceivingRosterId = tradePOSTDTO.SecondPartyRosterId
            };

            tradePlayers.Add(tradePlayer);
        }

        foreach (var playerId in tradePOSTDTO.SecondPartyOffering)
        {
            var playerExists = SecondPartyRoster.RosterPlayers.Any(rp => rp.PlayerId == playerId);
            if (!playerExists)
            {
                return BadRequest($"PlayerId {playerId} is not on Roster {SecondPartyRoster.RosterId}.");
            }

            var tradePlayer = new TradePlayer
            {
                PlayerId = playerId,
                GivingRosterId = tradePOSTDTO.SecondPartyRosterId,
                ReceivingRosterId = tradePOSTDTO.FirstPartyRosterId
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
            WeekActivation = TradeWeek,
            TradePlayers = tradePlayers
        };

        _dbContext.Trades.Add(NewTrade);
        _dbContext.SaveChanges();

        return Ok();
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetByLeagueAndUser(int rosterId, int leagueId)
    {
        // checks start here
        if (rosterId == 0 || leagueId == 0)
        {
            return BadRequest("One or both of rosterId, leagueId was 0 for Get Trades");
        }

        var userTrades = _dbContext.Trades
            .Where(t => t.LeagueId == leagueId)
            .Where(t => t.FirstPartyRosterId == rosterId || t.SecondPartyRosterId == rosterId)
            .Where(t => t.TradeComplete == false)
            .Select(t => new TradeDTO
            {
                TradeId = t.TradeId,
                LeagueId = t.LeagueId,
                FirstPartyRosterId = t.FirstPartyRosterId,
                SecondPartyRosterId = t.SecondPartyRosterId,
                FirstPartyAcceptance = t.FirstPartyAcceptance,
                SecondPartyAcceptance = t.SecondPartyAcceptance,
                WeekActivation = t.WeekActivation,
                TradeComplete = t.TradeComplete,
                TradePlayers = t.TradePlayers.Select(tp => new TradePlayerDTO
                {
                    TradePlayerId = tp.TradePlayerId,
                    TradeId = tp.TradeId,
                    GivingRosterId = tp.GivingRosterId,
                    ReceivingRosterId = tp.ReceivingRosterId,
                    PlayerId = tp.PlayerId
                }).ToList()
            });

        if (userTrades == null)
        {
            return BadRequest($"No available trades found for Roster {rosterId} League {leagueId}");
        }

        return Ok(userTrades);
    }
    
}