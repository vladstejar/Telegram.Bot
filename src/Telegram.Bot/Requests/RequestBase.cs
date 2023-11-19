using System.Net.Http;
using System.Text;
using Telegram.Bot.Requests.Abstractions;

namespace Telegram.Bot.Requests;

/// <summary>
/// Represents an API request
/// </summary>
/// <typeparam name="TResponse">Type of result expected in result</typeparam>
/// <param name="methodName">Bot API method</param>
/// <param name="method">HTTP method to use</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class RequestBase<TResponse>(string methodName, HttpMethod? method = default)
    : IRequest<TResponse>
{
    /// <inheritdoc />
    [JsonIgnore]
    public HttpMethod Method { get; } = method ?? HttpMethod.Post;

    /// <inheritdoc />
    [JsonIgnore]
    public string MethodName { get; } = methodName;

    /// <summary>
    /// Generate content of HTTP message
    /// </summary>
    /// <returns>Content of HTTP request</returns>
    public virtual HttpContent? ToHttpContent() =>
        new StringContent(
            content: JsonConvert.SerializeObject(this),
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
    [JsonProperty("method", DefaultValueHandling = DefaultValueHandling.Ignore)]
    internal string? WebHookMethodName => IsWebhookResponse ? MethodName : default;
}
