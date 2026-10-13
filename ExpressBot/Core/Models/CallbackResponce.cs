using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{

    public class CallbackOkResponce
    {
        [JsonPropertyName("sync_id")]
        public Guid SyncId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("result")]
        public object Result { get; set; }
    }
    public class CommandErrorResponse
    {
        [JsonPropertyName("sync_id")]
        public Guid SyncId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }

        [JsonPropertyName("error_data")]
        public object ErrorData { get; set; }
    }

}
