using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class User
    {
        [JsonPropertyName("user_huid")]
        public string UserHuid { get; set; }

        [JsonPropertyName("ad_login")]
        public string AdLogin { get; set; }

        [JsonPropertyName("ad_domain")]
        public string AdDomain { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("company_position")]
        public string CompanyPosition { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("emails")]
        public List<string> Emails { get; set; }

        [JsonPropertyName("other_id")]
        public string OtherId { get; set; }

        [JsonPropertyName("user_kind")]
        public string UserKind { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("cts_id")]
        public string CtsId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("ip_phone")]
        public int? IpPhone { get; set; }

        [JsonPropertyName("manager")]
        public string Manager { get; set; }

        [JsonPropertyName("office")]
        public string Office { get; set; }

        [JsonPropertyName("other_ip_phone")]
        public int? OtherIpPhone { get; set; }

        [JsonPropertyName("other_phone")]
        public string OtherPhone { get; set; }

        [JsonPropertyName("public_name")]
        public string PublicName { get; set; }

        [JsonPropertyName("rts_id")]
        public string RtsId { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
