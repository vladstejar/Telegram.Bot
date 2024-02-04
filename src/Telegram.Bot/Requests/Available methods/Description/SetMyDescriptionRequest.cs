namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change the bot's description, which is shown in the chat with the bot if the chat is empty.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class SetMyDescriptionRequest : RequestBase<bool>
{
    /// <summary>
    /// New bot description; 0-512 characters. Pass an empty string to remove the
    /// dedicated description for the given language.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? Description { get; set; }

    /// <summary>
    /// A two-letter ISO 639-1 language code. If empty, the description will be applied
    /// to all users for whose language there is no dedicated description.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? LanguageCode { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public SetMyDescriptionRequest()
        : base("setMyDescription")
    { }
}
