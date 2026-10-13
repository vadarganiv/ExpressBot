using ExpressBot.BotApi;
using ExpressBot.BotXApi;
using ExpressBot.Core.Models;
using Microsoft.Extensions.Logging;

namespace ExpressBot
{
    public class ExpressBotManager : BotXClient
    {
        private BotApiHost botHost;
        private readonly string botId;
        private readonly string ctsUrl;
        private readonly string hostUrl;
        private readonly string secretKey;
        private readonly ILoggerFactory loggerFactory;
        private bool isRunning;


        public ExpressBotManager(string botId, string ctsUrl, string hostUrl, string secretKey, ILoggerFactory loggerFactory = null) : base(ctsUrl, loggerFactory)
        {
            this.botId = botId;
            this.ctsUrl = ctsUrl;
            this.hostUrl = hostUrl;
            this.secretKey = secretKey;
            this.loggerFactory = loggerFactory;
        }

        #region Start/Stop
        public async Task Start()
        {
            if (isRunning) return;

            await Authorize(botId, secretKey);

            botHost = new BotApiHost(hostUrl, loggerFactory);
            botHost.StartListening(hostUrl);
            botHost.CommandRecived += (m) => MessageRecived?.Invoke(m);

            isRunning = true;
        }

        public async Task Stop()
        {
            if (!isRunning) return;

            botHost.StopListening();

            isRunning = false;
        }

        #endregion

        public event MessageHandler MessageRecived;
        public delegate void MessageHandler(CommandRequest message);

    }

}
