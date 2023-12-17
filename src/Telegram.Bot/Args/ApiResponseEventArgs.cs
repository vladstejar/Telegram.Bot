using System.Net.Http;

namespace Telegram.Bot.Args;

/// <summary>
/// Provides data for ApiResponseReceived event
/// </summary>
/// <remarks>
/// Initialize an <see cref="ApiResponseEventArgs"/> object
/// </remarks>
/// <param name="responseMessage">HTTP response received from API</param>
/// <param name="apiRequestEventArgs">Event arguments of this request</param>
public class ApiResponseEventArgs(
    HttpResponseMessage responseMessage,
    ApiRequestEventArgs apiRequestEventArgs)
{
    /// <summary>
    /// HTTP response received from API
    /// </summary>
    public HttpResponseMessage ResponseMessage { get; } = responseMessage;

    /// <summary>
    /// Event arguments of this request
    /// </summary>
    public ApiRequestEventArgs ApiRequestEventArgs { get; } = apiRequestEventArgs;
}
