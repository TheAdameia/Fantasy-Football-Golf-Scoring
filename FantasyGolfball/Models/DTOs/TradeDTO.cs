namespace FantasyGolfball.Models.DTOs;

public class TradeDTO
{
    public int TradeId { get; set; }
    public int LeagueId { get; set; }
    public int FirstPartyRosterId { get; set; }
    public int SecondPartyRosterId { get; set; }
    public required ICollection<TradePlayerDTO> TradePlayers { get; set; }
    public int WeekActivation { get; set; } // indicates when the trade will take effect
    public bool FirstPartyAcceptance { get; set; }
    public bool SecondPartyAcceptance { get; set; }
    public bool TradeComplete { get; set; }
}