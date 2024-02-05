#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
using Telegram.Bot.Converters;
#else
using Newtonsoft.Json.Converters;
#endif
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// Contains information about the current status of a webhook.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class WebhookInfo
{
    /// <summary>
    /// Webhook URL, may be empty if webhook is not set up
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Url { get; set; } = default!;

    /// <summary>
    /// <see langword="true"/>, if a custom certificate was provided for webhook certificate checks
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool HasCustomCertificate { get; set; }

    /// <summary>
    /// Number of updates awaiting delivery
    /// </summary>
    [DataMember(IsRequired = true)]
    public int PendingUpdateCount { get; set; }

    /// <summary>
    /// Optional. Currently used webhook IP address
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? IpAddress { get; set; }

    /// <summary>
    /// Optional. Time for the most recent error that happened when trying to deliver an update via webhook
    /// </summary>
    [JsonConverter(typeof(UnixDateTimeConverter))]
    [DataMember(EmitDefaultValue = false)]
    public DateTime? LastErrorDate { get; set; }

    /// <summary>
    /// Optional. Error message in human-readable format for the most recent error that happened when trying to
    /// deliver an update via webhook
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? LastErrorMessage { get; set; }

    /// <summary>
    /// Optional. Unix time of the most recent error that happened when trying to synchronize available updates
    /// with Telegram datacenters
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? LastSynchronizationErrorDate { get; set; }

    /// <summary>
    /// Optional. Maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MaxConnections { get; set; }

    /// <summary>
    /// Optional. A list of update types the bot is subscribed to. Defaults to all update types except
    /// <see cref="UpdateType.ChatMember"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public UpdateType[]? AllowedUpdates { get; set; }
}
