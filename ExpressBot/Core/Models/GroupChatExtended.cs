using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class GroupChatExtended
    {
        [JsonPropertyName("chat_type")]
        public string ChatType { get; set; }

        [JsonPropertyName("creator")]
        public Guid Creator { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }

        [JsonPropertyName("inserted_at")]
        public DateTime InsertedAt { get; set; }

        [JsonPropertyName("members")]
        public List<Member> Members { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shared_history")]
        public bool SharedHistory { get; set; }
    }
}
