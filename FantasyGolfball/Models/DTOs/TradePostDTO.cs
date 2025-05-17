namespace FantasyGolfball.Models.DTOs;

public class TradePOSTDTO
{
    public int TradeId { get; set; }
    public int LeagueId { get; set; }
    public int FirstPartyRosterId { get; set; }
    public int SecondPartyRosterId { get; set; }
    public required List<int> TradePieces { get; set; }
    public int WeekActivation { get; set; } // indicates when the trade will take effect
}