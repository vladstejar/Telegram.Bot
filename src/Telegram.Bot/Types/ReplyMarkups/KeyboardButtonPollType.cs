namespace Telegram.Bot.Types.ReplyMarkups;

/// <summary>
/// This object represents type of a poll, which is allowed to be created and sent when the corresponding button is pressed.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class KeyboardButtonPollType
{
    /// <summary>
    /// Optional. If quiz is passed, the user will be allowed to create only polls in the quiz mode. If regular is passed, only regular polls will be allowed. Otherwise, the user will be allowed to create a poll of any type.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Type { get; set; }
}
