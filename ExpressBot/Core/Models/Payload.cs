using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
  

    public class Opts
    {
        [JsonPropertyName("silent_response")]
        public bool SilentResponse { get; set; }

        [JsonPropertyName("buttons_auto_adjust")]
        public bool ButtonsAutoAdjust { get; set; }
    }
}
