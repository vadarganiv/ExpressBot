using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class GroupChatIdItem
    {
        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }
    }
}
