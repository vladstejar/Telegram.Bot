// using Telegram.Bot.Types.Enums;
// using JsonException = System.Text.Json.JsonException;
//
// namespace Telegram.Bot.Converters;
//
// internal partial class EmojiConverter : JsonConverter<Emoji>
// {
//     public override Emoji Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
//         !JsonElement.TryParseValue(ref reader, out var element)
//             ? (Emoji)0
//             : element.Value.ToString() switch
//             {
//                 "🎲" => Emoji.Dice,
//                 "🎯" => Emoji.Darts,
//                 "🏀" => Emoji.Basketball,
//                 "⚽" => Emoji.Football,
//                 "🎰" => Emoji.SlotMachine,
//                 "🎳" => Emoji.Bowling,
//                 _ => (Emoji)0,
//             };
//
//     public override void Write(Utf8JsonWriter writer, Emoji value, JsonSerializerOptions options)
//     {
//         writer.WriteStringValue(value switch
//         {
//             Emoji.Dice => "🎲",
//             Emoji.Darts => "🎯",
//             Emoji.Basketball => "🏀",
//             Emoji.Football => "⚽",
//             Emoji.SlotMachine => "🎰",
//             Emoji.Bowling => "🎳",
//             (Emoji)0 => "unknown",
//             _ => throw new JsonException(),
//         });
//     }
// }
