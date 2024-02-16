using System.Net.Http;

// ReSharper disable once UnusedTypeParameter
namespace Telegram.Bot.Requests.Abstractions;

/// <summary>
/// Represents a request to Bot API
/// </summary>
public interface IRequest
{
    /// <summary>
    /// HTTP method of request
    /// </summary>
    [JsonIgnore]
    HttpMethod Method { get; }

    /// <summary>
    /// API method name
    /// </summary>
    [JsonIgnore]
    string MethodName { get; }

    /// <summary>
    /// Allows this object to be used as a response in webhooks
    /// </summary>
    [JsonIgnore]
    bool IsWebhookResponse { get; set; }

    /// <summary>
    /// Generate content of HTTP message
    /// </summary>
    /// <returns>Content of HTTP request</returns>
    HttpContent? ToHttpContent();
}
