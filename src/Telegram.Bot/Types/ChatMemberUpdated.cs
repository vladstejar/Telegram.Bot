#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
using Telegram.Bot.Converters;
#else
using Newtonsoft.Json.Converters;
#endif

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents changes in the status of a chat member.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatMemberUpdated
{
    /// <summary>
    /// Chat the user belongs to
    /// </summary>
    [DataMember(IsRequired = true)]
    public Chat Chat { get; set; } = default!;

    /// <summary>
    /// Performer of the action, which resulted in the change
    /// </summary>
    [DataMember(IsRequired = true)]
    public User From { get; set; } = default!;

    /// <summary>
    /// Date the change was done
    /// </summary>
    [JsonConverter(typeof(UnixDateTimeConverter))]
    [DataMember(IsRequired = true)]
    public DateTime Date { get; set; }

    /// <summary>
    /// Previous information about the chat member
    /// </summary>
    [DataMember(IsRequired = true)]
    public ChatMember OldChatMember { get; set; } = default!;

    /// <summary>
    /// New information about the chat member
    /// </summary>
    [DataMember(IsRequired = true)]
    public ChatMember NewChatMember { get; set; } = default!;

    /// <summary>
    /// Optional. Chat invite link, which was used by the user to join the chat; for joining by invite link
    /// events only.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ChatInviteLink? InviteLink { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user joined the chat via a chat folder invite link
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? ViaChatFolderInviteLink { get; set; }
}
