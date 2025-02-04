﻿namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object represents information about an order.
/// </summary>
public partial class OrderInfo
{
    /// <summary>
    /// <em>Optional</em>. User name
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    /// <em>Optional</em>. User's phone number
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// <em>Optional</em>. User email
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Email { get; set; }

    /// <summary>
    /// <em>Optional</em>. User shipping address
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ShippingAddress? ShippingAddress { get; set; }
}
