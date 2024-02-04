using System.Collections.Generic;
#if !NET8_0_OR_GREATER
using Newtonsoft.Json.Converters;
#endif
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Converters;
// ReSharper disable CheckNamespace

namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send a native poll. On success, the sent <see cref="Message"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class SendPollRequest : RequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
#if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
#endif
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Poll question, 1-300 characters
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
#endif
    public string Question { get; }

    /// <summary>
    /// A list of answer options, 2-10 strings 1-100 characters each
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
#endif
    public IEnumerable<string> Options { get; }

    /// <summary>
    /// <see langword="true"/>, if the poll needs to be anonymous, defaults to <see langword="true"/>
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? IsAnonymous { get; set; }

    /// <summary>
    /// Poll type, defaults to <see cref="PollType.Regular"/>
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public PollType? Type { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the poll allows multiple answers, ignored for polls in quiz mode, defaults to
    /// <see langword="false"/>
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? AllowsMultipleAnswers { get; set; }

    /// <summary>
    /// 0-based identifier of the correct answer option, required for polls in quiz mode
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public int? CorrectOptionId { get; set; }

    /// <summary>
    /// Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a
    /// quiz-style poll, 0-200 characters with at most 2 line feeds after entities parsing
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? Explanation { get; set; }

    /// <summary>
    /// Mode for parsing entities in the explanation. See
    /// <a href="https://core.telegram.org/bots/api#formatting-options">formatting options</a>
    /// for more details.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public ParseMode? ExplanationParseMode { get; set; }

    /// <summary>
    /// List of special entities that appear in the poll explanation, which can be specified instead
    /// of <see cref="ParseMode"/>
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public IEnumerable<MessageEntity>? ExplanationEntities { get; set; }

    /// <summary>
    /// Amount of time in seconds the poll will be active after creation, 5-600. Can't be used
    /// together with <see cref="CloseDate"/>.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public int? OpenPeriod { get; set; }

    /// <summary>
    /// Point in time when the poll will be automatically closed. Must be at least 5 and no more
    /// than 600 seconds in the future. Can't be used together with <see cref="OpenPeriod"/>.
    /// </summary>
    [JsonConverter(typeof(UnixDateTimeConverter))]
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public DateTime? CloseDate { get; set; }

    /// <summary>
    /// Pass <see langword="true"/>, if the poll needs to be immediately closed. This can be useful for poll preview.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? IsClosed { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId, question and <see cref="PollOption"/>
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="question">Poll question, 1-300 characters</param>
    /// <param name="options">A list of answer options, 2-10 strings 1-100 characters each</param>
    public SendPollRequest(ChatId chatId, string question, IEnumerable<string> options)
        : base("sendPoll")
    {
        ChatId = chatId;
        Question = question;
        Options = options;
    }
}
