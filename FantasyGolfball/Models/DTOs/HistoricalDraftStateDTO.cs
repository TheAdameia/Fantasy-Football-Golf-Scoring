namespace FantasyGolfball.Models.DTOs;
public class HistoricalDraftStateDTO
{
    public int HistoricalDraftStateId { get; set; }
    public int LeagueId { get; set; }
    public required Queue<int> PermanentDraftOrder { get; set; }
    public required Dictionary<int, List<int>> UserRosters { get; set; }
}