namespace Telegram.Bot.Types;

/// <summary>
/// A placeholder, currently holds no information. Use <a href="https://t.me/botfather">@BotFather</a>
/// to set up your game.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class CallbackGame
{
}
