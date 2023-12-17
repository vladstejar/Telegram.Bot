namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a messageId.
/// </summary>
public class MessageId
{
    /// <summary>
    /// Message identifier in the chat specified in <see cref="Requests.CopyMessageRequest.FromChatId"/>
    /// </summary>
    [JsonPropertyName("message_id")]
    public int Id { get; set; }
}
