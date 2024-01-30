// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

namespace Telegram.Bot.Converters;

internal static class UnixDateTimeConverterUtil
{
    private static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    internal static DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var seconds = reader.GetInt64();
        if (seconds < 0)
            throw new JsonException($"Cannot convert value that is before Unix epoch of 00:00:00 UTC on 1 January 1970 to {typeToConvert:CultureInfo.InvariantCulture}.");

        return UnixEpoch.AddSeconds(seconds);
    }

    internal static void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        long seconds = (long)(value.ToUniversalTime() - UnixEpoch).TotalSeconds;
        if (seconds < 0)
            throw new JsonException("Cannot convert date value that is before Unix epoch of 00:00:00 UTC on 1 January 1970.");

        writer.WriteNumberValue(seconds);
    }
}

internal class UnixDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => UnixDateTimeConverterUtil.Read(ref reader, typeToConvert, options);

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => UnixDateTimeConverterUtil.Write(writer, value, options);
}

internal class NullableUnixDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var underlyingType = Nullable.GetUnderlyingType(typeToConvert);
        if (reader.TokenType is JsonTokenType.Null)
        {
            if (underlyingType is null)
                throw new JsonException($"Cannot convert null value to {typeToConvert:CultureInfo.InvariantCulture}.");

            return default;
        }

        return UnixDateTimeConverterUtil.Read(ref reader, typeToConvert, options);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value is  null) throw new JsonException("Expected date object value.");

        UnixDateTimeConverterUtil.Write(writer, value.Value, options);
    }
}
