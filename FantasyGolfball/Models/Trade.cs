namespace FantasyGolfball.Models;

public class Trade
{
    public int TradeId { get; set; }
    public int LeagueId { get; set; }
    public int FirstPartyRosterId { get; set; }
    public int SecondPartyRosterId { get; set; }
    public required ICollection<TradePlayer> TradePlayers { get; set; }
    public int WeekActivation { get; set; } // indicates when the trade will take effect
    public bool FirstPartyAcceptance { get; set; }
    public bool SecondPartyAcceptance { get; set; }
}