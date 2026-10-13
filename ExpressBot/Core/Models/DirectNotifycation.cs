using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpressBot.Core.Models
{
    public class DirectNotification : BaseEvent
    {
        [JsonPropertyName("group_chat_id")]
        public Guid GroupChatId { get; set; }

        [JsonPropertyName("recipients")]
        public object Recipients { get; set; }  // Assuming this is dynamic or null

        [JsonPropertyName("notification")]
        public Notification Notification { get; set; }

        [JsonPropertyName("file")]
        public File File { get; set; }

        [JsonPropertyName("opts")]
        public Options Opts { get; set; }
    }

    public class Notification
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("metadata")]
        public dynamic Metadata { get; set; }

        [JsonPropertyName("opts")]
        public NotificationOptions Options { get; set; }

        [JsonPropertyName("bubble")]
        public Bubble[][] Bubble { get; set; }

        [JsonPropertyName("keyboard")]
        public KeyboardItem[][] Keyboard { get; set; }

        [JsonPropertyName("mentions")]
        public Mention[] Mentions { get; set; }
    }

    public class NotificationOptions
    {
        [JsonPropertyName("silent_response")]
        public bool SilentResponse { get; set; }

        [JsonPropertyName("buttons_auto_adjust ")]
        public bool ButtonsAutoAdjust { get; set; }
    }

    public class Bubble
    {
        [JsonPropertyName("command")]
        public string Command { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("opts")]
        public ButtonOptions Options { get; set; }

        [JsonPropertyName("data")]
        public dynamic Data { get; set; }
    }

    public class ButtonOptions
    {
        [JsonPropertyName("silent")]
        public bool Silent { get; set; } = false;

        [JsonPropertyName("h_size")]
        public int HSize { get; set; } = 1;

        [JsonPropertyName("show_alert")]
        public bool ShowAlert { get; set; } = false;

        [JsonPropertyName("alert_text")]
        public string AlertText { get; set; } = null;

        [JsonPropertyName("font_color")]
        public string FontColor { get; set; } = null;

        [JsonPropertyName("background_color")]
        public string BackgroundColor { get; set; } = null;

        [JsonPropertyName("align")]
        public string Align { get; set; } = "left";
    }

    public class Options
    {
        [JsonPropertyName("stealth_mode")]
        public bool StealthMode { get; set; }

        [JsonPropertyName("notification_opts")]
        public NotificationOpts NotificationOpts { get; set; }
    }

    public class NotificationOpts
    {
        [JsonPropertyName("send")]
        public bool Send { get; set; }

        [JsonPropertyName("force_dnd")]
        public bool ForceDnd { get; set; }
    }


}
