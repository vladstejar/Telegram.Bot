using System.Net.Http;
using System.Text;
using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

namespace Telegram.Bot.Requests;

/// <summary>
/// Represents an API request
/// </summary>
/// <typeparam name="TResponse">Type of result expected in result</typeparam>
/// <param name="methodName">Bot API method</param>
/// <param name="method">HTTP method to use</param>
public abstract class RequestBase<TResponse>(string methodName, HttpMethod? method = default)
    : IRequest<TResponse>
{
    /// <inheritdoc />
    [JsonIgnore]
    public HttpMethod HttpMethod { get; } = method ?? HttpMethod.Post;

    /// <inheritdoc />
    [JsonIgnore]
    public string MethodName { get; } = methodName;

    /// <summary>
    /// Generate content of HTTP message
    /// </summary>
    /// <returns>Content of HTTP request</returns>
    public virtual HttpContent? ToHttpContent() =>
        new StringContent(
            content: JsonSerializer.Serialize(this, JsonSerializerOptionsProvider.Options),
            encoding: Encoding.UTF8,
            mediaType: "application/json"
        );

    /// <inheritdoc />
    [JsonIgnore]
    public bool IsWebhookResponse { get; set; }

    /// <summary>
    /// If <see cref="IsWebhookResponse"/> is set to <see langword="true"/> is set to the method
    /// name, otherwise it won't be serialized
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method => IsWebhookResponse ? MethodName : default;
}
