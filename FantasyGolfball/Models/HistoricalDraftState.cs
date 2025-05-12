using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace FantasyGolfball.Models;
public class HistoricalDraftState
{
    public int HistoricalDraftStateId { get; set; }
    public int LeagueId { get; set; }
    [Required]
    public string PermanentDraftOrderJson { get; set; } = string.Empty;
    // [Required]
    public string UserRostersJson { get; set; } = string.Empty;
    [NotMapped]
    public Queue<int> PermanentDraftOrder
    {
        get => JsonConvert.DeserializeObject<Queue<int>>(PermanentDraftOrderJson);
        set => PermanentDraftOrderJson = JsonConvert.SerializeObject(value);
    }
    [NotMapped]
    public Dictionary<int, List<int>> UserRosters
    {
        get => JsonConvert.DeserializeObject<Dictionary<int, List<int>>>(UserRostersJson);
        set => UserRostersJson = JsonConvert.SerializeObject(value);
    }
}