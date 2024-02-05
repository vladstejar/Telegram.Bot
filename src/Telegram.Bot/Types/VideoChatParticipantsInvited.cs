namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about new members invited to a video chat.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class VideoChatParticipantsInvited
{
    /// <summary>
    /// Optional. New members that were invited to the voice chat
    /// </summary>
    [DataMember(IsRequired = true)]
    public User[] Users { get; set; } = default!;
}
