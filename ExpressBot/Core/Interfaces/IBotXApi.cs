using ExpressBot.Core.Models;

namespace ExpressBot.Core.Interfaces
{
    public interface IBotXApi
    {
        Task<BotXVersion> GetBotXVersionAsync();
        Task<TokenAnswer> GetTokenAsync(string botId, string secretKey);
        Task<BotListResponse> GetBotListAsync(string sinceDateTime);
        // Notifications
        Task<StatusResponce<SyncIdItem>> SendDirectNotificationAsync(DirectNotification directNotification);
        Task<StatusResponce> SendInternalNotificationAsync(InternalNotification notificationPayload);
        // Events 
        Task<StatusResponce> EditEventAsync(EditEvent editEvent);
        Task<StatusResponce> ReplyToEventAsync(ReplyEvent replyEvent);
        Task<StatusResponce> GetEventStatusAsync(string syncId);
        Task<StatusResponce> SendTypingAsync(GroupChatIdItem chatId);
        Task<StatusResponce> StopTypingAsync(GroupChatIdItem chatId);
        Task<StatusResponce> DeleteEventAsync(SyncIdItem eventId);
        // Chats
        Task<StatusResponce<List<GroupChat>>> GetChatsListAsync();
        Task<StatusResponce<GroupChatExtended>> GetChatInfoAsync(Guid chatId);
        Task<StatusResponce> AddUsersToChatAsync(GroupChatWithUsersItem addUsersToChatItem);
        Task<StatusResponce> RemoveUsersFromChatAsync(GroupChatWithUsersItem groupChatWithUsersItem);
        Task<StatusResponce> AddAdminToChatAsync(GroupChatWithUsersItem groupChatWithUsersItem);
        Task<StatusResponce> EnableStealthModeAsync(StealthSettings stealthSettings);
        Task<StatusResponce> DisableStealthModeAsync(GroupChatIdItem chatId);
        Task<StatusResponce> CreateChatAsync(NewChatSettings newChatSettings);
        Task<StatusResponce> PinMessageAsync(PinRef pinRef);
        Task<StatusResponce> UnpinMessageAsync(ChatIdItem chatId);
        // Users
        Task<StatusResponce<List<User>>> GetUserByEmailAsync(EmailsList emails);
        Task<StatusResponce<User>> GetUserByHuidAsync(Guid huid);
        Task<StatusResponce<User>> GetUserByLoginAsync(string login, string domain);
        Task<StatusResponce<User>> GetUserByOtherIdAsync(string otherId);
        Task<string> GetUsersAsCsvAsync();
        Task<StatusResponce> UpdateUserProfileAsync(UserUpdateItem profile);
        //Files
        Task<byte[]> DownloadFileAsync(string groupChatId, string fileId, string isPreview);
        Task<StatusResponce> UploadFileAsync(byte[] fileData, string fileName);

    }
}

