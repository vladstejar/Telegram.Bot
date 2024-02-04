namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a forum topic reopened in the chat. Currently holds no information.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class ForumTopicReopened { }
