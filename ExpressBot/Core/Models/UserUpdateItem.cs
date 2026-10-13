using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class UserUpdateItem
    {
        [JsonPropertyName("user_huid")]
        public string UserHuid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("public_name")]
        public string PublicName { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("company_position")]
        public string CompanyPosition { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("office")]
        public string Office { get; set; }

        [JsonPropertyName("manager")]
        public string Manager { get; set; }
    }
}
