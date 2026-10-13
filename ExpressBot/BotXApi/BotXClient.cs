using ExpressBot.Core.Interfaces;
using ExpressBot.Core.Models;
using ExpressBot.Core.Utilities;
using Microsoft.Extensions.Logging;

namespace ExpressBot.BotXApi
{
    public class BotXClient : BaseClient, IBotXApi
    {
        public BotXClient(string ctsUrl, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _httpClient.BaseAddress = new Uri(ctsUrl);
        }

        protected override void SetLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<BotXClient>();
        }

        protected async Task Authorize(string bot_id, string secretKey)
        {
            var signature = SignatureHelper.CreateHmacSha256Signature(bot_id, secretKey);
            var token = await GetTokenAsync(bot_id, signature);
            SetBearerToken(token.Result);
        }

        public async Task<BotXVersion> GetBotXVersionAsync()
        {
            return await SendGetRequestAsync<BotXVersion>("/system/botx/version");
        }

        public async Task<TokenAnswer> GetTokenAsync(string bot_id, string signature)
        {
            return await SendGetRequestAsync<TokenAnswer>($"/api/v2/botx/bots/{bot_id}/token?signature={signature}");
        }

        public async Task<BotListResponse> GetBotListAsync(string sinceDateTime)
        {
            return await SendGetRequestAsync<BotListResponse>($"/api/v1/botx/bots/catalog?since={sinceDateTime}");
        }

        public async Task<StatusResponce<SyncIdItem>> SendDirectNotificationAsync(DirectNotification payload)
        {
            return await SendPostRequestAsync<StatusResponce<SyncIdItem>>("/api/v4/botx/notifications/direct", payload);
        }

        public async Task<StatusResponce> SendInternalNotificationAsync(InternalNotification notificationPayload)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v4/botx/notifications/internal", notificationPayload);
        }

        public async Task<StatusResponce> EditEventAsync(EditEvent editEvent)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/events/edit_event", editEvent);
        }

        public async Task<StatusResponce> ReplyToEventAsync(ReplyEvent replyEvent)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/events/reply_event", replyEvent);
        }

        public async Task<StatusResponce> GetEventStatusAsync(string syncId)
        {
            return await SendGetRequestAsync<StatusResponce>($"/api/v3/botx/events/{syncId}/status");
        }

        public async Task<StatusResponce> SendTypingAsync(GroupChatIdItem chatIdItem)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/events/typing", chatIdItem);
        }

        public async Task<StatusResponce> StopTypingAsync(GroupChatIdItem chatIdItem)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/events/stop_typing", chatIdItem);
        }

        public async Task<StatusResponce> DeleteEventAsync(SyncIdItem SyncIdItem)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/events/delete_event", SyncIdItem);
        }

        public async Task<StatusResponce<List<GroupChat>>> GetChatsListAsync()
        {
            return await SendGetRequestAsync<StatusResponce<List<GroupChat>>>("/api/v3/botx/chats/list");
        }

        public async Task<StatusResponce<GroupChatExtended>> GetChatInfoAsync(Guid chatId)
        {
            return await SendGetRequestAsync<StatusResponce<GroupChatExtended>>($"/api/v3/botx/chats/info?chat_id={chatId.ToString()}");
        }

        public async Task<StatusResponce> AddUsersToChatAsync(GroupChatWithUsersItem addUsersToChatItem)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/chats/add_user", addUsersToChatItem);
        }

        public async Task<StatusResponce> RemoveUsersFromChatAsync(GroupChatWithUsersItem groupChatWithUsersItem)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/chats/remove_user", groupChatWithUsersItem);
        }

        public async Task<StatusResponce> AddAdminToChatAsync(GroupChatWithUsersItem groupChatWithUsersItem)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/chats/add_admin", groupChatWithUsersItem);
        }

        public async Task<StatusResponce> EnableStealthModeAsync(StealthSettings stealthSettings)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/chats/stealth_set", stealthSettings);
        }

        public async Task<StatusResponce> DisableStealthModeAsync(GroupChatIdItem chatId)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/chats/stealth_disable", chatId);
        }

        public async Task<StatusResponce> CreateChatAsync(NewChatSettings newChatSettings)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/chats/create", newChatSettings);
        }

        public async Task<StatusResponce> PinMessageAsync(PinRef pinRef)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/chats/pin_message", pinRef);
        }

        public async Task<StatusResponce> UnpinMessageAsync(ChatIdItem chatIdItem)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/chats/unpin_message", chatIdItem);
        }

        public async Task<StatusResponce<List<User>>> GetUserByEmailAsync(EmailsList emails)
        {
            return await SendPostRequestAsync<StatusResponce<List<User>>>("/api/v3/botx/users/by_email", emails);
        }

        public async Task<StatusResponce<User>> GetUserByHuidAsync(Guid huid)
        {
            return await SendGetRequestAsync<StatusResponce<User>>($"/api/v3/botx/users/by_huid?huid={huid.ToString()}");
        }

        public async Task<StatusResponce<User>> GetUserByLoginAsync(string login, string domain)
        {
            return await SendGetRequestAsync<StatusResponce<User>>($"/api/v3/botx/users/by_login?login={login}&domain={domain}");
        }

        public async Task<StatusResponce<User>> GetUserByOtherIdAsync(string otherId)
        {
            return await SendGetRequestAsync<StatusResponce<User>>($"/api/v3/botx/users/by_other_id?other_id={otherId}");
        }

        public async Task<string> GetUsersAsCsvAsync()
        {
            return await SendGetRequestAsync<string>("/api/v3/botx/users/users_as_csv");
        }

        public async Task<StatusResponce> UpdateUserProfileAsync(UserUpdateItem profile)
        {
            return await SendPostRequestAsync<StatusResponce>("/api/v3/botx/users/update_profile", profile);
        }

        public async Task<byte[]> DownloadFileAsync(string groupChatId, string fileId, string isPreview)
        {
            throw new NotImplementedException();
            //return await SendGetRequestAsync<byte[]>($"/api/v3/botx/files/download?file_id={fileId}");
        }

        public async Task<StatusResponce> UploadFileAsync(byte[] fileData, string fileName)
        {
            throw new NotImplementedException();
            //return await SendPostRequestAsync<string>("/api/v3/botx/files/upload", payload);
        }
    }
}

