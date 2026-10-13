using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class BotXVersion
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
