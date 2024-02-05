namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a Telegram user or bot.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class User
{
    /// <summary>
    /// Unique identifier for this user or bot
    /// </summary>
    [DataMember(IsRequired = true)]
    public long Id { get; set; }

    /// <summary>
    /// <see langword="true"/>, if this user is a bot
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool IsBot { get; set; }

    /// <summary>
    /// User's or bot’s first name
    /// </summary>
    [DataMember(IsRequired = true)]
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Optional. User's or bot’s last name
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? LastName { get; set; }

    /// <summary>
    /// Optional. User's or bot’s username
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Username { get; set; }

    /// <summary>
    /// Optional. <a href="https://en.wikipedia.org/wiki/IETF_language_tag">IETF language tag</a> of the
    /// user's language
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if this user is a Telegram Premium user
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? IsPremium { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if this user added the bot to the attachment menu
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? AddedToAttachmentMenu { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the bot can be invited to groups. Returned only in <see cref="Requests.GetMeRequest"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanJoinGroups { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if privacy mode is disabled for the bot. Returned only in <see cref="Requests.GetMeRequest"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanReadAllGroupMessages { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the bot supports inline queries. Returned only in <see cref="Requests.GetMeRequest"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? SupportsInlineQueries { get; set; }

    /// <inheritdoc/>
    public override string ToString() =>
        $"{(Username is null ? $"{FirstName}{LastName?.Insert(0, " ")}" : $"@{Username}")} ({Id})";
}
