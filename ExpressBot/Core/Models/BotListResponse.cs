using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class BotListResponse
    {
        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("bots")]
        public List<Bot> Bots { get; set; }
    }

    public class Bot
    {
        [JsonPropertyName("user_huid")]
        public string UserHuid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }
}
