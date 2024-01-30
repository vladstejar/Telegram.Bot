using System.Buffers;

namespace Telegram.Bot.Converters;

internal readonly struct Rune
{
    public readonly int Value { get; }

    private Rune(int value) => Value = value;

    public static OperationStatus DecodeFromUtf16(ReadOnlySpan<char> source, out Rune result, out int charsConsumed)
    {
        if (!source.IsEmpty)
        {
            char firstChar = source[0];

            if (!char.IsSurrogate(firstChar))
            {
                result = new(firstChar);
                charsConsumed = 1;
                return OperationStatus.Done;
            }

            if (source.Length > 1)
            {
                char lowSurrogate = source[1];

                if (char.IsSurrogatePair(firstChar, lowSurrogate))
                {
                    result = new(char.ConvertToUtf32(firstChar, lowSurrogate));
                    charsConsumed = 2;
                    return OperationStatus.Done;
                }
                else
                {
                    goto InvalidData;
                }
            }
            else if (!char.IsHighSurrogate(firstChar))
            {
                goto InvalidData;
            }
        }

        charsConsumed = source.Length;
        result = default;
        return OperationStatus.NeedMoreData;

        InvalidData:
        charsConsumed = 1;
        result = new(0xFFFD); // Replacement char
        return OperationStatus.InvalidData;
    }
}
