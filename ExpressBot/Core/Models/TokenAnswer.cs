using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class TokenAnswer
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("result")]
        public string Result { get; set; }
    }
}
