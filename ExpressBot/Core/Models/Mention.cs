using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class Mention
    {
        [JsonPropertyName("mention_type")]
        public string MentionType { get; set; } // "user" | "chat" | "contact"

        [JsonPropertyName("mention_id")]
        public Guid MentionId { get; set; }

        [JsonPropertyName("mention_data")]
        public MentionData MentionData { get; set; }
    }
}
