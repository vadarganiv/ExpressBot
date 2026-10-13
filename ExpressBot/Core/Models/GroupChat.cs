using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class GroupChat
    {
        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }

        [JsonPropertyName("chat_type")]
        public string ChatType { get; set; } // "group_chat"

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("members")]
        public List<Guid> Members { get; set; } // List of UUIDs representing members

        [JsonPropertyName("shared_history")]
        public bool SharedHistory { get; set; }

        [JsonPropertyName("inserted_at")]
        public DateTime InsertedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
