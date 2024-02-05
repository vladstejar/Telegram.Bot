

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// This object represents the content of a message to be sent as a result of an
/// <see cref="InlineQuery">inline query</see>.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#else
[JsonPolymorphic(TypeDiscriminatorPropertyName = null)]
[JsonDerivedType(typeof(InputContactMessageContent))]
[JsonDerivedType(typeof(InputInvoiceMessageContent))]
[JsonDerivedType(typeof(InputLocationMessageContent))]
[JsonDerivedType(typeof(InputTextMessageContent))]
[JsonDerivedType(typeof(InputVenueMessageContent))]
#endif
[DataContract]
public abstract class InputMessageContent { }
