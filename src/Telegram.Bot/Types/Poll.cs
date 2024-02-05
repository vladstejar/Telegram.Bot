#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
using Telegram.Bot.Converters;
#else
using Newtonsoft.Json.Converters;
#endif

namespace Telegram.Bot.Types;

/// <summary>
/// This object contains information about a poll.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class Poll
{
    /// <summary>
    /// Unique poll identifier
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Id { get; set; } = default!;

    /// <summary>
    /// Poll question, 1-300 characters
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Question { get; set; } = default!;

    /// <summary>
    /// List of poll options
    /// </summary>
    [DataMember(IsRequired = true)]
    public PollOption[] Options { get; set; } = default!;

    /// <summary>
    /// Total number of users that voted in the poll
    /// </summary>
    [DataMember(IsRequired = true)]
    public int TotalVoterCount { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the poll is closed
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool IsClosed { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the poll is anonymous
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool IsAnonymous { get; set; }

    /// <summary>
    /// Poll type, currently can be “regular” or “quiz”
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Type { get; set; } = default!;

    /// <summary>
    /// <see langword="true"/>, if the poll allows multiple answers
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool AllowsMultipleAnswers { get; set; }

    /// <summary>
    /// Optional. 0-based identifier of the correct answer option. Available only for polls in the quiz mode,
    /// which are closed, or was sent (not forwarded) by the bot or to the private chat with the bot.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? CorrectOptionId { get; set; }

    /// <summary>
    /// Optional. Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a
    /// quiz-style poll, 0-200 characters
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Explanation { get; set; }

    /// <summary>
    /// Optional. Special entities like usernames, URLs, bot commands, etc. that appear in the
    /// <see cref="Explanation"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public MessageEntity[]? ExplanationEntities { get; set; }

    /// <summary>
    /// Optional. Amount of time in seconds the poll will be active after creation
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? OpenPeriod { get; set; }

    /// <summary>
    /// Optional. Point in time when the poll will be automatically closed
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? CloseDate { get; set; }
}
