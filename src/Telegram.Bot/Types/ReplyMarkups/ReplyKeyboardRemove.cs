namespace Telegram.Bot.Types.ReplyMarkups;

/// <summary>
/// Upon receiving a message with this object, Telegram clients will remove the current custom keyboard and display the default letter-keyboard. By default, custom keyboards are displayed until a new keyboard is sent by a bot. An exception is made for one-time keyboards that are hidden immediately after the user presses a button (see <see cref="ReplyKeyboardMarkup"/>).
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class ReplyKeyboardRemove : ReplyMarkupBase
{
    /// <summary>
    /// Requests clients to remove the custom keyboard (user will not be able to summon this keyboard; if you want to hide the keyboard from sight but keep it accessible, use '<see cref="ReplyKeyboardMarkup.OneTimeKeyboard"/>' in <see cref="ReplyKeyboardMarkup"/>)
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public bool RemoveKeyboard => true;
}
