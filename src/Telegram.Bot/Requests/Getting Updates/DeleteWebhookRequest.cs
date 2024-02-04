// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to remove webhook integration if you decide to switch back to
/// <see cref="GetUpdatesRequest"/>. Returns <see langword="true"/> on success.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class DeleteWebhookRequest : RequestBase<bool>
{
    /// <summary>
    /// Pass <see langword="true"/> to drop all pending updates
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? DropPendingUpdates { get; set; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    public DeleteWebhookRequest()
        : base("deleteWebhook")
    { }
}
