namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about General forum topic hidden in the chat.
/// Currently holds no information.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class GeneralForumTopicHidden { }
