

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// This object represents the content of a message to be sent as a result of an
/// <see cref="InlineQuery">inline query</see>.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public abstract class InputMessageContent { }
