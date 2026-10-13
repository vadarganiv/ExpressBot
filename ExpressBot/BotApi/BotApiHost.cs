using ExpressBot.Core.Interfaces;
using ExpressBot.Core.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ExpressBot.BotApi
{
    public class BotApiHost : IBotApi
    {
        private readonly HttpListener _listener;
        private readonly ILogger _logger;
        private readonly string _baseAddress;

        public event CommandHandler CommandRecived;
        public delegate void CommandHandler(CommandRequest message);

        public event CallbackHandler CallbackRecived;
        public delegate void CallbackHandler(CallbackOkResponce message);


        public BotApiHost(string baseAddress, ILoggerFactory loggerFactory)
        {
            _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            _listener = new HttpListener();
            _logger = loggerFactory.CreateLogger<BotApiHost>();
        }

        #region Controls
        public void StartListening(string prefix)
        {
            _listener.Prefixes.Add(prefix);

            _listener.Start();
            _logger?.LogTrace("Started listening for incoming requests at {Prefix}", prefix);
            Task.Run(() => ListenForRequestsAsync());
        }

        public void StopListening()
        {
            _listener.Stop();
            _logger?.LogTrace("Stopped listening for incoming requests");
        }

        #endregion

        private async Task ListenForRequestsAsync()
        {
            while (true)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    var request = context.Request;
                    var response = context.Response;

                    _logger?.LogTrace("Received {Method} request for {Url}", request.HttpMethod, request.Url.AbsolutePath);

                    if (request.Url.AbsolutePath == "/command")
                    {
                        await ProcessCommandAsync(context);
                    }
                    else if (request.Url.AbsolutePath == "/notification/callback")
                    {
                        await HandleNotificationCallbackAsync(context);
                    }
                    else if (request.Url.AbsolutePath == "/status")
                    {
                        await GetBotStatusAsync(context);
                    }
                    else
                    {
                        _logger?.LogWarning("Unhandled request path: {Path}", request.Url.AbsolutePath);
                        response.StatusCode = 404;
                        await response.OutputStream.WriteAsync(Encoding.UTF8.GetBytes("Not Found"));
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Error processing request");
                }
            }
        }

        #region IBotApi

        public async Task ProcessCommandAsync(HttpListenerContext context)
        {
            try
            {
                using (var reader = new StreamReader(context.Request.InputStream, Encoding.UTF8))
                {
                    var requestBody = await reader.ReadToEndAsync();

                    var commandRequest = JsonSerializer.Deserialize<CommandRequest>(requestBody);

                    CommandRecived?.Invoke(commandRequest);

                    _logger?.LogTrace("Received command: {Command}", commandRequest?.Command?.Body);
                }

                await SendCommangAcceptedAsync(context);
            }
            catch (Exception ex)
            {
                await SendBotDisabledResponseAsync(context);
                _logger?.LogError(ex, "Error processing /command request");

            }
            finally
            {
                context.Response.Close();
            }
        }

        public async Task HandleNotificationCallbackAsync(HttpListenerContext context)
        {
            try
            {
                using (var reader = new StreamReader(context.Request.InputStream, Encoding.UTF8))
                {
                    var requestBody = await reader.ReadToEndAsync();

                    var callbackRequest = JsonSerializer.Deserialize<CallbackOkResponce>(requestBody);

                    CallbackRecived?.Invoke(callbackRequest);

                    _logger?.LogTrace("Received Callback: {Callback}", callbackRequest);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error processing callback");
                context.Response.StatusCode = 500;
            }
        }

        public async Task GetBotStatusAsync(HttpListenerContext context)
        {
            try
            {
                _logger?.LogTrace("Status check request received");

                context.Response.StatusCode = 200;

                var responseContent = new StatusResponce() { Status = "ok", Result = new ResultData() { Enabled = true } };
                var jsonResponse = System.Text.Json.JsonSerializer.Serialize(responseContent);

                context.Response.ContentType = "application/json";
                context.Response.ContentEncoding = Encoding.UTF8;

                using (var writer = new StreamWriter(context.Response.OutputStream, Encoding.UTF8))
                {
                    await writer.WriteAsync(jsonResponse);
                }

                _logger?.LogTrace("Status response sent successfully");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error processing status request");
                context.Response.StatusCode = 500;
                await context.Response.OutputStream.WriteAsync(Encoding.UTF8.GetBytes($"Error: {ex.Message}"));
            }
        }

        private async Task SendBotDisabledResponseAsync(HttpListenerContext context)
        {
            context.Response.StatusCode = 503;

            var responseObject = new
            {
                reason = "bot_disabled",
                error_data = new
                {
                    status_message = "please stand by"
                },
                errors = new string[] { }
            };

            var jsonResponse = JsonSerializer.Serialize(responseObject);

            context.Response.ContentType = "application/json";
            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(jsonResponse);

            using (var writer = new StreamWriter(context.Response.OutputStream))
            {
                await writer.WriteAsync(jsonResponse);
                await writer.FlushAsync();
            }

        }

        private async Task SendCommangAcceptedAsync(HttpListenerContext context)
        {
            context.Response.StatusCode = 202;

            var responseContent = new { result = "accepted" };
            var jsonResponse = System.Text.Json.JsonSerializer.Serialize(responseContent);

            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;

            using (var writer = new StreamWriter(context.Response.OutputStream, Encoding.UTF8))
            {
                await writer.WriteAsync(jsonResponse);
            }

            _logger?.LogTrace("Processed /command request successfully.");
        }

        public Task RequestSmartappDataAsync(HttpListenerContext context)
        {
            throw new NotImplementedException();
        }

        public Task GetSmartappStaticFileAsync(HttpListenerContext context, string path)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
