namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object represents a shipping address.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ShippingAddress
{
    /// <summary>
    /// ISO 3166-1 alpha-2 country code
    /// </summary>
    [DataMember(IsRequired = true)]
    public string CountryCode { get; set; } = default!;

    /// <summary>
    /// State, if applicable
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string State { get; set; } = default!;

    /// <summary>
    /// City
    /// </summary>
    [DataMember(IsRequired = true)]
    public string City { get; set; } = default!;

    /// <summary>
    /// First line for the address
    /// </summary>
    [DataMember(IsRequired = true)]
    public string StreetLine1 { get; set; } = default!;

    /// <summary>
    /// Second line for the address
    /// </summary>
    [DataMember(IsRequired = true)]
    public string StreetLine2 { get; set; } = default!;

    /// <summary>
    /// Address post code
    /// </summary>
    [DataMember(IsRequired = true)]
    public string PostCode { get; set; } = default!;
}
