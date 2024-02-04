#if NET7_0_OR_GREATER
using System.Text.Json;
#else
using Newtonsoft.Json;
#endif

using Telegram.Bot.Converters;

namespace Telegram.Bot.Tests.Unit;

internal static class Serializer
{
#if NET7_0_OR_GREATER
    public static T? Deserialize<T>(string value)
        => JsonSerializer.Deserialize<T>(value, JsonSerializerOptionsProvider.Options);

    public static string Serialize<T>(T value)
        => JsonSerializer.Serialize(value, JsonSerializerOptionsProvider.Options);
#else
    public static T? Deserialize<T>(string value, JsonSerializerSettings? settings = default) => JsonConvert.DeserializeObject<T>(value, settings);
    public static string Serialize<T>(T value, JsonSerializerSettings? settings = default) => JsonConvert.SerializeObject(value, settings);
#endif
}
