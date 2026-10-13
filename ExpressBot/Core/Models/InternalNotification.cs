using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class InternalNotification
    {
        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }

        [JsonPropertyName("data")]
        public ChatData Data { get; set; }

        [JsonPropertyName("opts")]
        public ChatOptions Opts { get; set; }

        [JsonPropertyName("recipients")]
        public object Recipients { get; set; }
    }

    public class ChatData
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class ChatOptions
    {
        [JsonPropertyName("internal_token")]
        public string InternalToken { get; set; }
    }
}
