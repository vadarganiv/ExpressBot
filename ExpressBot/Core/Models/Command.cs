using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class CommandData
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("command_type")]
        public string CommandType { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }

        [JsonPropertyName("metadata")]
        public object Metadata { get; set; }
    }


    public class Attachment
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("data")]
        public AttachmentData Data { get; set; }
    }

    public class AttachmentData
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("file_name")]
        public string FileName { get; set; }
    }

    public class DeviceMeta
    {
        [JsonPropertyName("permissions")]
        public Permissions Permissions { get; set; }

        [JsonPropertyName("pushes")]
        public bool Pushes { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }

    public class Permissions
    {
        [JsonPropertyName("microphone")]
        public bool Microphone { get; set; }

        [JsonPropertyName("notifications")]
        public bool Notifications { get; set; }
    }

    public class FromData
    {
        [JsonPropertyName("user_huid")]
        public string UserHuid { get; set; }

        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }

        [JsonPropertyName("ad_login")]
        public string AdLogin { get; set; }

        [JsonPropertyName("ad_domain")]
        public string AdDomain { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("is_creator")]
        public bool IsCreator { get; set; }

        [JsonPropertyName("chat_type")]
        public string ChatType { get; set; }

        [JsonPropertyName("host")]
        public string Host { get; set; }

        [JsonPropertyName("app_version")]
        public string AppVersion { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("device_software")]
        public string DeviceSoftware { get; set; }

        [JsonPropertyName("device_meta")]
        public DeviceMeta DeviceMeta { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("platform_package_id")]
        public string PlatformPackageId { get; set; }
    }

    public class Entity
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("data")]
        public EntityData Data { get; set; }
    }

    public class EntityData
    {
        [JsonPropertyName("mention_type")]
        public string MentionType { get; set; }

        [JsonPropertyName("mention_id")]
        public string MentionId { get; set; }

        [JsonPropertyName("mention_data")]
        public MentionDataWithConnType MentionData { get; set; }
    }

    public class MentionDataWithConnType
    {
        [JsonPropertyName("user_huid")]
        public string UserHuid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("conn_type")]
        public string ConnType { get; set; }
    }

    public class CommandRequest
    {
        [JsonPropertyName("sync_id")]
        public Guid SyncId { get; set; }

        [JsonPropertyName("command")]
        public CommandData Command { get; set; }

        [JsonPropertyName("attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonPropertyName("async_files")]
        public List<object> AsyncFiles { get; set; }

        [JsonPropertyName("from")]
        public FromData From { get; set; }

        [JsonPropertyName("bot_id")]
        public string BotId { get; set; }

        [JsonPropertyName("proto_version")]
        public int ProtoVersion { get; set; }

        [JsonPropertyName("entities")]
        public List<Entity> Entities { get; set; }
    }


}
