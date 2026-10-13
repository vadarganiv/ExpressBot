using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class MentionData
    {
        [JsonPropertyName("user_huid")]
        public Guid UserHuid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }
    }
}
