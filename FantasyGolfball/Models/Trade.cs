namespace FantasyGolfball.Models;

public class Trade
{
    public int TradeId { get; set; }
    public int FirstPartyRosterId { get; set; }
    public int SecondPartyRosterId { get; set; }
    public required ICollection<RosterPlayer> TradePieces { get; set; } // the idea is you can map RosterPlayers to a side of a trade using RosterId
}