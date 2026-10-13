using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExpressBot.BotXApi
{
    public abstract class BaseClient
    {
        protected readonly HttpClient _httpClient = new HttpClient();
        protected ILogger _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        protected BaseClient(ILoggerFactory loggerFactory)
        {
            SetLogger(loggerFactory);

            _jsonOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

        }

        protected virtual void SetLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<BaseClient>();
        }

        public void SetBearerToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Bearer token cannot be null or empty.", nameof(token));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        protected async Task<T> SendGetRequestAsync<T>(string url)
        {
            _logger?.LogTrace("GET {Url}", url);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            _logger?.LogTrace("Response: {Content}", content);

            return JsonSerializer.Deserialize<T>(content, _jsonOptions) ?? throw new InvalidOperationException("Failed to deserialize response.");
        }

        protected async Task<T> SendPostRequestAsync<T>(string url, object payload)
        {
            _logger?.LogTrace("POST {Url} with payload {Payload}", url, JsonSerializer.Serialize(payload, _jsonOptions));

            var content = new StringContent(JsonSerializer.Serialize(payload, _jsonOptions), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
           

            var result = await response.Content.ReadAsStringAsync();

            _logger?.LogInformation("Bot request payload: {content}", JsonSerializer.Serialize(payload, _jsonOptions));
            _logger?.LogTrace("Response: {Content}", result);


            response.EnsureSuccessStatusCode();



            return JsonSerializer.Deserialize<T>(result) ?? throw new InvalidOperationException("Failed to deserialize response.");
        }

        protected async Task SendPostRequestAsync(string url, object payload)
        {
            _logger?.LogTrace("POST {Url} with payload {Payload}", url, JsonSerializer.Serialize(payload, _jsonOptions));

            var content = new StringContent(JsonSerializer.Serialize(payload, _jsonOptions), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            var result = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            _logger?.LogTrace("Request to {Url} completed successfully", url);
        }
    }
}
