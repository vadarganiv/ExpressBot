using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class KeyboardItem
    {
        [JsonPropertyName("command")]
        public string Command { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }

        [JsonPropertyName("opts")]
        public KeyboardOptions Options { get; set; }
    }
}
