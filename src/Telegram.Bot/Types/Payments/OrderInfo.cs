namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object represents information about an order.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class OrderInfo
{
    /// <summary>
    /// Optional. User name
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? Name { get; set; }

    /// <summary>
    /// Optional. User's phone number
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Optional. User email
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? Email { get; set; }

    /// <summary>
    /// Optional. User shipping address
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public ShippingAddress? ShippingAddress { get; set; }
}
