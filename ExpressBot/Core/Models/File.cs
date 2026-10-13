using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class File
    {
        [JsonPropertyName("file_name")]
        public string FileName { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; } // Data URL with base64 encoding
    }
}
