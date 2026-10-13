using System.Net;

namespace ExpressBot.Core.Interfaces
{
    public interface IBotApi
    {
        Task ProcessCommandAsync(HttpListenerContext context);

        Task HandleNotificationCallbackAsync(HttpListenerContext context);

        Task RequestSmartappDataAsync(HttpListenerContext context);

        Task GetSmartappStaticFileAsync(HttpListenerContext context, string path);

        Task GetBotStatusAsync(HttpListenerContext context);
    }

}
