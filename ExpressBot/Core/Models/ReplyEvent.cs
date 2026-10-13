using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class ReplyEvent
    {
        [JsonPropertyName("source_sync_id")]
        public Guid SourceSyncId { get; set; }

        [JsonPropertyName("reply")]
        public Notification Reply { get; set; }

        [JsonPropertyName("file")]
        public object File { get; set; }

        [JsonPropertyName("opts")]
        public Opts Opts { get; set; }
    }
}
