using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class ChatIdItem
    {
        [JsonPropertyName("chat_id")]
        public Guid ChatId { get; set; }
    }
}
