namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object represents a shipping address.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class ShippingAddress
{
    /// <summary>
    /// ISO 3166-1 alpha-2 country code
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string CountryCode { get; set; } = default!;

    /// <summary>
    /// State, if applicable
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string State { get; set; } = default!;

    /// <summary>
    /// City
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string City { get; set; } = default!;

    /// <summary>
    /// First line for the address
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string StreetLine1 { get; set; } = default!;

    /// <summary>
    /// Second line for the address
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string StreetLine2 { get; set; } = default!;

    /// <summary>
    /// Address post code
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string PostCode { get; set; } = default!;
}
