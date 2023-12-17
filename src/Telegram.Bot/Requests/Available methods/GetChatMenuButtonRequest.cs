// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to get the current value of the bot’s menu button in a private chat, or the default menu button.
/// Returns <see cref="MenuButton"/> on success.
/// </summary>
public class GetChatMenuButtonRequest() : RequestBase<MenuButton>("getChatMenuButton")
{
    /// <summary>
    /// Optional. Unique identifier for the target private chat. If not specified, default bot’s menu button
    /// will be changed
    /// </summary>
    public long? ChatId { get; set; }
}
