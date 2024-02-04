namespace Telegram.Bot.Types.ReplyMarkups;

/// <summary>
/// A marker interface for reply markups that define how a <see cref="User"/> can reply to the sent <see cref="Message"/>
/// </summary>
#if NET7_0_OR_GREATER
[JsonPolymorphic(TypeDiscriminatorPropertyName = null)]
[JsonDerivedType(typeof(ForceReplyMarkup))]
[JsonDerivedType(typeof(ReplyKeyboardMarkup))]
[JsonDerivedType(typeof(InlineKeyboardMarkup))]
[JsonDerivedType(typeof(ReplyKeyboardRemove))]
#endif
public interface IReplyMarkup;
