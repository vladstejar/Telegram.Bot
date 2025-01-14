﻿namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send answers to callback queries sent from <a href="https://core.telegram.org/bots/features#inline-keyboards">inline keyboards</a>. The answer will be displayed to the user as a notification at the top of the chat screen or as an alert<para>Returns: </para>
/// </summary>
/// <remarks>
/// Alternatively, the user can be redirected to the specified Game URL. For this option to work, you must first create a game for your bot via <a href="https://t.me/botfather">@BotFather</a> and accept the terms. Otherwise, you may use links like <c>t.me/your_bot?start=XXXX</c> that open your bot with a parameter.
/// </remarks>
public partial class AnswerCallbackQueryRequest : RequestBase<bool>
{
    /// <summary>
    /// Unique identifier for the query to be answered
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string CallbackQueryId { get; set; }

    /// <summary>
    /// Text of the notification. If not specified, nothing will be shown to the user, 0-200 characters
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    /// <summary>
    /// If <see langword="true"/>, an alert will be shown by the client instead of a notification at the top of the chat screen. Defaults to <see langword="false"/>.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ShowAlert { get; set; }

    /// <summary>
    /// URL that will be opened by the user's client. If you have created a <see cref="Game"/> and accepted the conditions via <a href="https://t.me/botfather">@BotFather</a>, specify the URL that opens your game - note that this will only work if the query comes from a <see cref="InlineKeyboardButton"><em>CallbackGame</em></see> button.<br/><br/>Otherwise, you may use links like <c>t.me/your_bot?start=XXXX</c> that open your bot with a parameter.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    /// <summary>
    /// The maximum amount of time in seconds that the result of the callback query may be cached client-side. Telegram apps will support caching starting in version 3.14. Defaults to 0.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CacheTime { get; set; }

    /// <summary>
    /// Initializes an instance of <see cref="AnswerCallbackQueryRequest"/>
    /// </summary>
    /// <param name="callbackQueryId">Unique identifier for the query to be answered</param>
    [Obsolete("Use parameterless constructor with required properties")]
    [SetsRequiredMembers]
    public AnswerCallbackQueryRequest(string callbackQueryId)
        : this() => CallbackQueryId = callbackQueryId;

    /// <summary>
    /// Instantiates a new <see cref="AnswerCallbackQueryRequest"/>
    /// </summary>
    public AnswerCallbackQueryRequest()
        : base("answerCallbackQuery")
    { }
}
