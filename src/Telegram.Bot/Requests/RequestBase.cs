using System.Net.Http;
using System.Text;
using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

namespace Telegram.Bot.Requests;

/// <summary>
/// Represents an API request
/// </summary>
/// <typeparam name="TResponse">Type of result expected in result</typeparam>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public abstract class RequestBase<TResponse> : IRequest<TResponse>
{
    /// <inheritdoc />
    [JsonIgnore]
    public HttpMethod Method { get; }

    /// <inheritdoc />
    [JsonIgnore]
    public string MethodName { get; }

    /// <summary>
    /// Initializes an instance of request
    /// </summary>
    /// <param name="methodName">Bot API method</param>
    protected RequestBase(string methodName)
        : this(methodName, HttpMethod.Post)
    { }

    /// <summary>
    /// Initializes an instance of request
    /// </summary>
    /// <param name="methodName">Bot API method</param>
    /// <param name="method">HTTP method to use</param>
    protected RequestBase(string methodName, HttpMethod method) =>
        (MethodName, Method) = (methodName, method);

    /// <summary>
    /// Generate content of HTTP message
    /// </summary>
    /// <returns>Content of HTTP request</returns>
    public virtual HttpContent? ToHttpContent() =>
        new StringContent(
            content:
#if NET8_0_OR_GREATER
                JsonSerializer.Serialize(this, JsonSerializerOptionsProvider.Options),
#else
                JsonConvert.SerializeObject(this),
#endif
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

#if NET8_0_OR_GREATER
    [JsonPropertyName("method")]
    [JsonInclude]
#endif
    [DataMember(Name = "method", EmitDefaultValue = true)]
    internal string? WebHookMethodName => IsWebhookResponse ? MethodName : default;
}
