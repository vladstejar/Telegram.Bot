namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a message about a forwarded story in the chat. Currently holds no information.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class Story
{
}
