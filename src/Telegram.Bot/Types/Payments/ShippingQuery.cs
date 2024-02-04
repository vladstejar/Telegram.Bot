namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object contains information about an incoming shipping query.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class ShippingQuery
{
    /// <summary>
    /// Unique query identifier
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string Id { get; set; } = default!;

    /// <summary>
    /// User who sent the query
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public User From { get; set; } = default!;

    /// <summary>
    /// Bot specified invoice payload
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string InvoicePayload { get; set; } = default!;

    /// <summary>
    /// User specified shipping address
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public ShippingAddress ShippingAddress { get; set; } = default!;
}
