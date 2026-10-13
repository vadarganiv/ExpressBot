using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class Member
    {
        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        [JsonPropertyName("server_id")]
        public Guid ServerId { get; set; }

        [JsonPropertyName("user_huid")]
        public Guid UserHuid { get; set; }

        [JsonPropertyName("user_kind")]
        public string UserKind { get; set; }
    }
}
