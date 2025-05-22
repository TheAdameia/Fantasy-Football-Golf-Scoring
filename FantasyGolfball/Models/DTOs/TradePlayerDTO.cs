namespace FantasyGolfball.Models.DTOs;

public class TradePlayerDTO
{
    public int TradePlayerId { get; set; }
    public int TradeId { get; set; }
    public int PlayerId { get; set; }
    public int GivingRosterId { get; set; }
    public int ReceivingRosterId { get; set; }
}