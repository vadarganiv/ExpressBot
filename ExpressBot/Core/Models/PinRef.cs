using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class PinRef
    {
        [JsonPropertyName("chat_id")]
        public Guid ChatId { get; set; }

        [JsonPropertyName("sync_id")]
        public Guid SyncId { get; set; }
    }
}
