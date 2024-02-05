using System.Net.Http;

namespace Telegram.Bot.Requests;

/// <summary>
/// Represents a request that doesn't require any parameters
/// </summary>
/// <typeparam name="TResult"></typeparam>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ParameterlessRequest<TResult> : RequestBase<TResult>
{
    /// <summary>
    /// Initializes an instance of <see cref="ParameterlessRequest{TResult}"/>
    /// </summary>
    /// <param name="methodName">Name of request method</param>
    public ParameterlessRequest(string methodName)
        : base(methodName)
    { }

    /// <summary>
    /// Initializes an instance of <see cref="ParameterlessRequest{TResult}"/>
    /// </summary>
    /// <param name="methodName">Name of request method</param>
    /// <param name="method">HTTP request method</param>
    public ParameterlessRequest(string methodName, HttpMethod method)
        : base(methodName, method)
    { }

    /// <inheritdoc cref="RequestBase{TResponse}.ToHttpContent"/>
    public override HttpContent? ToHttpContent() =>
        IsWebhookResponse
            ? base.ToHttpContent()
            : default;
}
