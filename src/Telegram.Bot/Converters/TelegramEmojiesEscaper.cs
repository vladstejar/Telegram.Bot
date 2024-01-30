using System.Buffers;
using System.Text.Encodings.Web;

namespace Telegram.Bot.Converters;

internal unsafe class TelegramEmojiesEscaper : JavaScriptEncoder
{
    public override int MaxOutputCharactersPerInputCharacter => Default.MaxOutputCharactersPerInputCharacter;

    public override int FindFirstCharacterToEncode(char* text, int textLength)
    {
        ReadOnlySpan<char> input = new ReadOnlySpan<char>(text, textLength);
        int idx = 0;

        // Enumerate until we're out of data or saw invalid input
        while (Rune.DecodeFromUtf16(input.Slice(idx), out Rune result, out int charsConsumed) == OperationStatus.Done)
        {
            if (WillEncode(result.Value)) { break; } // found a char that needs to be escaped
            idx += charsConsumed;
        }

        if (idx == input.Length) { return -1; } // walked entire input without finding a char which needs escaping
        return idx;
    }

    public override bool WillEncode(int unicodeScalar) =>
        // Allow for specific emojies that are used in the Bot API
        // and for all other chars defer to the default escaper.
        unicodeScalar switch
        {
            0x1F603 => false,
            _ => Default.WillEncode(unicodeScalar)
        };

    public override bool TryEncodeUnicodeScalar(int unicodeScalar, char* buffer, int bufferLength, out int numberOfCharactersWritten)
    {
        // For anything that needs to be escaped, defer to the default escaper.
        return Default.TryEncodeUnicodeScalar(unicodeScalar, buffer, bufferLength, out numberOfCharactersWritten);
    }
}
