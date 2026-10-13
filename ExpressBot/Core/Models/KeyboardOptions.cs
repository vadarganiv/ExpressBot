using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class KeyboardOptions
    {
        [JsonPropertyName("silent")]
        public bool Silent { get; set; }

        [JsonPropertyName("h_size")]
        public int HSize { get; set; }

        [JsonPropertyName("show_alert")]
        public bool ShowAlert { get; set; }

        [JsonPropertyName("alert_text")]
        public string AlertText { get; set; }

        [JsonPropertyName("font_color")]
        public string FontColor { get; set; }

        [JsonPropertyName("background_color")]
        public string BackgroundColor { get; set; }

        [JsonPropertyName("align")]
        public string Align { get; set; } // "left" | "center" | "right"
    }
}
