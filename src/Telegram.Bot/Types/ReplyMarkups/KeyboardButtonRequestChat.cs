namespace Telegram.Bot.Types.ReplyMarkups;

/// <summary>
/// This object defines the criteria used to request a suitable chat. The identifier of the selected chat will be
/// shared with the bot when the corresponding button is pressed.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class KeyboardButtonRequestChat
{
    /// <summary>
    /// Signed 32-bit identifier of the request
    /// </summary>
    [DataMember(IsRequired = true)]
    public int RequestId { get; set; }

    /// <summary>
    /// Pass <see langword="true" /> to request a channel chat, pass <see langword="false" /> to request a group
    /// or a supergroup chat.
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool ChatIsChannel { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true" /> to request a forum supergroup, pass <see langword="false" /> to
    /// request a non-forum chat. If not specified, no additional restrictions are applied.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? ChatIsForum { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true" /> to request a supergroup or a channel with a username,
    /// pass <see langword="false" /> to request a chat without a username. If not specified, no additional
    /// restrictions are applied.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? ChatHasUsername { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true" /> to request a chat owned by the user. Otherwise, no additional
    /// restrictions are applied.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? ChatIsCreated { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized object listing the required administrator rights of the user in the chat.
    /// If not specified, no additional restrictions are applied.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ChatAdministratorRights? UserAdministratorRights { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized object listing the required administrator rights of the bot in the chat.
    /// The rights must be a subset of <see cref="ChatAdministratorRights" />. If not specified, no additional
    /// restrictions are applied.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ChatAdministratorRights? BotAdministratorRights { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true" /> to request a chat with the bot as a member. Otherwise, no additional
    /// restrictions are applied.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool BotIsMember { get; set; }
}
