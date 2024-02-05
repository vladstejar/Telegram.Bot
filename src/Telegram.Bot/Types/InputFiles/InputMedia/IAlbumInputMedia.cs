// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// A marker for input media types that can be used in sendMediaGroup method.
/// </summary>
#if NET8_0_OR_GREATER
[JsonPolymorphic(TypeDiscriminatorPropertyName = null)]
[JsonDerivedType(typeof(InputMediaAudio))]
[JsonDerivedType(typeof(InputMediaDocument))]
[JsonDerivedType(typeof(InputMediaPhoto))]
[JsonDerivedType(typeof(InputMediaVideo))]
#endif
public interface IAlbumInputMedia;
