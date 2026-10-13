using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class EditEvent : BaseEvent
    {
        [JsonPropertyName("sync_id")]
        public Guid SyncId { get; set; }

        [JsonPropertyName("payload")]
        public Notification Payload { get; set; }

        [JsonPropertyName("file")]
        public File File { get; set; }

        [JsonPropertyName("opts")]
        public object Opts { get; set; }
    }

}
