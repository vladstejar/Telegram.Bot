namespace Telegram.Bot.Types;

/// <summary>
/// Describes actions that a non-administrator user is allowed to take in a chat.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatPermissions
{
    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to send text messages, contacts, locations and venues
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendMessages { get; set; }

    /// <summary>
    /// Optional. <see langword="true" />, if the user is allowed to send audios
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendAudios { get; set; }

    /// <summary>
    /// Optional. <see langword="true" />, if the user is allowed to send documents
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendDocuments { get; set; }

    /// <summary>
    /// Optional. <see langword="true" />, if the user is allowed to send photos
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendPhotos { get; set; }

    /// <summary>
    /// Optional. <see langword="true" />, if the user is allowed to send videos
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendVideos { get; set; }

    /// <summary>
    /// Optional. <see langword="true" />, if the user is allowed to send video notes
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendVideoNotes { get; set; }

    /// <summary>
    /// Optional. <see langword="true" />, if the user is allowed to send voice notes
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendVoiceNotes { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to send polls, implies <see cref="CanSendMessages"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendPolls { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to send animations, games, stickers and use inline
    /// bots
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanSendOtherMessages { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to add web page previews to their messages
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanAddWebPagePreviews { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to change the chat title, photo and other settings.
    /// Ignored in public supergroups
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanChangeInfo { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to invite new users to the chat
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanInviteUsers { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to pin messages. Ignored in public supergroups
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanPinMessages { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to create forum topics.
    /// If omitted defaults to the value of <see cref="CanPinMessages"/>
    /// supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanManageTopics { get; set; }
}
