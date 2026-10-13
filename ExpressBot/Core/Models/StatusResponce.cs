using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class StatusResponce<T>
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("result")]
        public T Result { get; set; }
    }

    public class StatusResponce
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("result")]
        public dynamic Result { get; set; }
    }

    public class ResultData
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("status_message")]
        public string StatusMessage { get; set; }

        [JsonPropertyName("commands")]
        public List<CommandDescriptions> Commands { get; set; }
    }

    public class CommandDescriptions
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}
