using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class StealthSettings
    {
        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }

        [JsonPropertyName("disable_web")]
        public bool DisableWeb { get; set; }

        [JsonPropertyName("burn_in")]
        public int BurnIn { get; set; }

        [JsonPropertyName("expire_in")]
        public int ExpireIn { get; set; }
    }
}
