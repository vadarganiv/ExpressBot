using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class NewChatSettings
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("chat_type")]
        public string ChatType { get; set; }

        [JsonPropertyName("members")]
        public List<Guid> Members { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("shared_history")]
        public bool SharedHistory { get; set; }
    }
}
