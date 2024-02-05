#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
using Telegram.Bot.Converters;
#else
using Newtonsoft.Json.Converters;
#endif

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a video chat scheduled in the chat.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class VideoChatScheduled
{
    /// <summary>
    /// Point in time when the voice chat is supposed to be started by a chat administrator
    /// </summary>
    [DataMember(IsRequired = true)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime StartDate { get; set; }
}
