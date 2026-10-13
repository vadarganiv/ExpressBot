using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class SyncIdItem
    {
        [JsonPropertyName("sync_id")]
        public Guid SyncId { get; set; }
    }
}
