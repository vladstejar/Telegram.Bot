#if NET8_0_OR_GREATER

using System.Collections.Generic;

namespace Telegram.Bot.Converters;

/// <summary>
///
/// </summary>
public static partial class JsonSerializerOptionsProvider
{
    static JsonSerializerOptionsProvider()
    {
        Options = new()
        {
            Converters =
            {
                new UnixDateTimeConverter(),
                new BanTimeConverter(),
                new ColorConverter(),
                new InputFileConverter(),
                new ChatIdConverter(),
            },
            PropertyNamingPolicy = new JsonSnakeCaseLowerNamingPolicy(),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        foreach (var generatedConverter in GeneratedConverters())
        {
            Options.Converters.Add(generatedConverter);
        }
    }

    /// <summary>
    ///
    /// </summary>
    public static JsonSerializerOptions Options { get; }

    private static partial IEnumerable<JsonConverter> GeneratedConverters();
}

#endif
