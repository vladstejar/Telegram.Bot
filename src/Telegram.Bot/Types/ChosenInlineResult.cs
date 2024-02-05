namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a result of an <see cref="InlineQuery"/> that was chosen by the <see cref="User"/>
/// and sent to their chat partner.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChosenInlineResult
{
    /// <summary>
    /// The unique identifier for the result that was chosen.
    /// </summary>
    [DataMember(IsRequired = true)]
    public string ResultId { get; set; } = default!;

    /// <summary>
    /// The user that chose the result.
    /// </summary>
    [DataMember(IsRequired = true)]
    public User From { get; set; } = default!;

    /// <summary>
    /// Optional. Sender location, only for bots that require user location
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Location? Location { get; set; }

    /// <summary>
    /// Optional. Identifier of the sent inline message. Available only if there is an inline keyboard attached
    /// to the message. Will be also received in callback queries and can be used to edit the message.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? InlineMessageId { get; set; }

    /// <summary>
    /// The query that was used to obtain the result.
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Query { get; set; } = default!;
}
