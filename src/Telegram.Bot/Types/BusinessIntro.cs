﻿namespace Telegram.Bot.Types;

/// <summary>
/// Contains information about the start page settings of a Telegram Business account.
/// </summary>
public partial class BusinessIntro
{
    /// <summary>
    /// <em>Optional</em>. Title text of the business intro
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    /// <em>Optional</em>. Message text of the business intro
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }

    /// <summary>
    /// <em>Optional</em>. Sticker of the business intro
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Sticker? Sticker { get; set; }
}
