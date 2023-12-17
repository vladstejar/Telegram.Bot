using Telegram.Bot.Converters;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a video chat scheduled in the chat.
/// </summary>
public class VideoChatScheduled
{
    /// <summary>
    /// Point in time when the voice chat is supposed to be started by a chat administrator
    /// </summary>
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime StartDate { get; set; }
}
