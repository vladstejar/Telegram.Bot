namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get the current <see cref="BotDescription">bot description</see>
/// for the given <see cref="LanguageCode">user language</see>.
/// Returns <see cref="BotDescription"/> on success.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class GetMyDescriptionRequest : RequestBase<BotDescription>
{
    /// <summary>
    /// A two-letter ISO 639-1 language code or an empty string
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? LanguageCode { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public GetMyDescriptionRequest()
        : base("getMyDescription")
    { }
}
