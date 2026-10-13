using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class EmailsList
    {
        [JsonPropertyName("emails")]
        public List<string> Emails { get; set; }
    }
}
