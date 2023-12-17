using JetBrains.Annotations;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Payments;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents an incoming update.
/// </summary>
/// <remarks>
/// Only <b>one</b> of the optional parameters can be present in any given update.
/// </remarks>
[PublicAPI]
public class Update
{
    /// <summary>
    /// The update's unique identifier. Update identifiers start from a certain positive number and increase
    /// sequentially. This ID becomes especially handy if you're using
    /// <a href="https://core.telegram.org/bots/api#setwebhook">Webhooks</a>, since it allows you to ignore repeated
    /// updates or to restore the correct update sequence, should they get out of order. If there are no new updates
    /// for at least a week, then identifier of the next update will be chosen randomly instead of sequentially.
    /// </summary>
    [JsonPropertyName("update_id")]
    public int Id { get; set; }

    /// <summary>
    /// Optional. New incoming message of any kind — text, photo, sticker, etc.
    /// </summary>
    public Message? Message { get; set; }

    /// <summary>
    /// Optional. New version of a message that is known to the bot and was edited
    /// </summary>
    public Message? EditedMessage { get; set; }

    /// <summary>
    /// Optional. New incoming channel post of any kind — text, photo, sticker, etc.
    /// </summary>
    public Message? ChannelPost { get; set; }

    /// <summary>
    /// Optional. New version of a channel post that is known to the bot and was edited
    /// </summary>
    public Message? EditedChannelPost { get; set; }

    /// <summary>
    /// Optional. New incoming inline query
    /// </summary>
    public InlineQuery? InlineQuery { get; set; }

    /// <summary>
    /// Optional. The result of a inline query that was chosen by a user and sent to their chat partner
    /// </summary>
    public ChosenInlineResult? ChosenInlineResult { get; set; }

    /// <summary>
    /// Optional. New incoming callback query
    /// </summary>
    public CallbackQuery? CallbackQuery { get; set; }

    /// <summary>
    /// Optional. New incoming shipping query. Only for invoices with flexible price
    /// </summary>
    public ShippingQuery? ShippingQuery { get; set; }

    /// <summary>
    /// Optional. New incoming pre-checkout query. Contains full information about checkout
    /// </summary>
    public PreCheckoutQuery? PreCheckoutQuery { get; set; }

    /// <summary>
    /// Optional. New poll state. Bots receive only updates about stopped polls and polls, which are sent by the bot
    /// </summary>
    public Poll? Poll { get; set; }

    /// <summary>
    /// Optional. A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were
    /// sent by the bot itself.
    /// </summary>
    public PollAnswer? PollAnswer { get; set; }

    /// <summary>
    /// Optional. The bot’s chat member status was updated in a chat. For private chats, this update is received
    /// only when the bot is blocked or unblocked by the user.
    /// </summary>
    public ChatMemberUpdated? MyChatMember { get; set; }

    /// <summary>
    /// Optional. A chat member's status was updated in a chat. The bot must be an administrator in the chat
    /// and must explicitly specify “<see cref="UpdateType.ChatMember"/>” in the list of allowed_updates to
    /// receive these updates.
    /// </summary>
    public ChatMemberUpdated? ChatMember { get; set; }

    /// <summary>
    /// Optional. A request to join the chat has been sent. The bot must have the
    /// <see cref="ChatPermissions.CanInviteUsers"/> administrator right in the chat to receive these updates.
    /// </summary>
    public ChatJoinRequest? ChatJoinRequest { get; set; }

    /// <summary>
    /// Gets the update type.
    /// </summary>
    /// <value>
    /// The update type.
    /// </value>
    public UpdateType Type => this switch
    {
        { Message: not null }            => UpdateType.Message,
        { EditedMessage: not null }      => UpdateType.EditedMessage,
        { InlineQuery: not null }        => UpdateType.InlineQuery,
        { ChosenInlineResult: not null } => UpdateType.ChosenInlineResult,
        { CallbackQuery: not null }      => UpdateType.CallbackQuery,
        { ChannelPost: not null }        => UpdateType.ChannelPost,
        { EditedChannelPost: not null }  => UpdateType.EditedChannelPost,
        { ShippingQuery: not null }      => UpdateType.ShippingQuery,
        { PreCheckoutQuery: not null }   => UpdateType.PreCheckoutQuery,
        { Poll: not null }               => UpdateType.Poll,
        { PollAnswer: not null }         => UpdateType.PollAnswer,
        { MyChatMember: not null }       => UpdateType.MyChatMember,
        { ChatMember: not null }         => UpdateType.ChatMember,
        { ChatJoinRequest: not null }    => UpdateType.ChatJoinRequest,
        _                                => UpdateType.Unknown
    };
}
