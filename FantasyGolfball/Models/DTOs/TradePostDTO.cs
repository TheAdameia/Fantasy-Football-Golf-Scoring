namespace FantasyGolfball.Models.DTOs;

public class TradePOSTDTO
{
    public int TradeId { get; set; }
    public int LeagueId { get; set; }
    public int FirstPartyRosterId { get; set; }
    public int SecondPartyRosterId { get; set; }
    public required List<int> FirstPartyOffering { get; set; }
    public required List<int> SecondPartyOffering { get; set; }
}