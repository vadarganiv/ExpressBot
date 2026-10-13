using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class GroupChatWithUsersItem
    {
        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }

        [JsonPropertyName("user_huids")]
        public List<Guid> UserHuids { get; set; }
    }
}
