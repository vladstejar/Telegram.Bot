namespace Telegram.Bot.Types.ReplyMarkups;

/// <summary>
/// Defines how clients display a reply interface to the <see cref="User"/>
/// </summary>
/// <seealso cref="Telegram.Bot.Types.ReplyMarkups.IReplyMarkup" />
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#else
[JsonPolymorphic(TypeDiscriminatorPropertyName = null)]
[JsonDerivedType(typeof(ForceReplyMarkup))]
[JsonDerivedType(typeof(ReplyKeyboardMarkup))]
[JsonDerivedType(typeof(ReplyKeyboardRemove))]
#endif
public abstract class ReplyMarkupBase : IReplyMarkup
{
    /// <summary>
    /// Optional. Use this parameter if you want to show the keyboard to specific users only. Targets:
    /// <list type="number">
    /// <item>
    /// users that are @mentioned in the <see cref="Message.Text"/> of the <see cref="Message"/> object;
    /// </item>
    /// <item>
    /// if the bot’s message is a reply (has <see cref="Message.ReplyToMessage"/>), sender of the original
    /// message.
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <i>Example:</i> A user requests to change the bot’s language, bot replies to the request with a keyboard
    /// to select the new language. Other users in the group don't see the keyboard.
    /// </remarks>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? Selective { get; set; }
}
