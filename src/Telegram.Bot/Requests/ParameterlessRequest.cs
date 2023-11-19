using System.Net.Http;

namespace Telegram.Bot.Requests;

/// <summary>
/// Represents a request that doesn't require any parameters
/// </summary>
/// <typeparam name="TResult"></typeparam>
/// <param name="methodName">Name of request method</param>
/// <param name="method">HTTP request method</param>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ParameterlessRequest<TResult>(string methodName, HttpMethod? method = default)
    : RequestBase<TResult>(methodName, method)
{
    /// <inheritdoc cref="RequestBase{TResponse}.ToHttpContent"/>
    public override HttpContent? ToHttpContent() =>
        IsWebhookResponse
            ? base.ToHttpContent()
            : default;
}
