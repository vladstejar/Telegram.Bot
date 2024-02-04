// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// A simple method for testing your bot’s auth token. Requires no parameters. Returns basic information
/// about the bot in form of a <see cref="User"/> object.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class GetMeRequest : ParameterlessRequest<User>
{
    /// <summary>
    /// Initializes a new request
    /// </summary>
    public GetMeRequest()
        : base("getMe")
    { }
}
