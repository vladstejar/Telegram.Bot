namespace Telegram.Bot.Types;

/// <summary>
/// This object represents an answer of a user in a non-anonymous poll.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class PollAnswer
{
    /// <summary>
    /// Unique poll identifier
    /// </summary>
    [DataMember(IsRequired = true)]
    public string PollId { get; set; } = default!;

    /// <summary>
    /// Optional. The chat that changed the answer to the poll, if the voter is anonymous
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public Chat? VoterChat { get; set; }

    /// <summary>
    /// Optional. The user that changed the answer to the poll, if the voter isn't anonymous
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public User? User { get; set; }

    /// <summary>
    /// 0-based identifiers of answer options, chosen by the user. May be empty if the user retracted their vote.
    /// </summary>
    [DataMember(IsRequired = true)]
    public int[] OptionIds { get; set; } = default!;
}
