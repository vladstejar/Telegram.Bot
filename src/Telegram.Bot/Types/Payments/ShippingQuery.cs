namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object contains information about an incoming shipping query.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ShippingQuery
{
    /// <summary>
    /// Unique query identifier
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Id { get; set; } = default!;

    /// <summary>
    /// User who sent the query
    /// </summary>
    [DataMember(IsRequired = true)]
    public User From { get; set; } = default!;

    /// <summary>
    /// Bot specified invoice payload
    /// </summary>
    [DataMember(IsRequired = true)]
    public string InvoicePayload { get; set; } = default!;

    /// <summary>
    /// User specified shipping address
    /// </summary>
    [DataMember(IsRequired = true)]
    public ShippingAddress ShippingAddress { get; set; } = default!;
}
