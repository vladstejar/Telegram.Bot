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

using System.Globalization;

namespace Telegram.Bot.Converters;

internal class UnixDateTimeConverter : JsonConverter<object?>
{
    private static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var underlyingType = Nullable.GetUnderlyingType(typeToConvert);
        if (reader.TokenType is JsonTokenType.Null)
        {
            if (underlyingType is null)
            {
                throw new JsonException($"Cannot convert null value to {typeToConvert:CultureInfo.InvariantCulture}.");
            }

            return null;
        }

        long seconds;

        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
            {
                seconds = reader.GetInt64();
                break;
            }
            case JsonTokenType.String:
            {
                if (!long.TryParse(reader.GetString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out seconds))
                {
                    throw new JsonException($"Cannot convert invalid value to {typeToConvert:CultureInfo.InvariantCulture}.");
                }

                break;
            }
            default:
                throw new JsonException($"Unexpected token parsing date. Expected Integer or String, got {reader.TokenType:CultureInfo.InvariantCulture}.");
        }

        if (seconds < 0)
        {
            throw new JsonException($"Cannot convert value that is before Unix epoch of 00:00:00 UTC on 1 January 1970 to {typeToConvert:CultureInfo.InvariantCulture}.");
        }

        DateTime d = UnixEpoch.AddSeconds(seconds);

        Type t = underlyingType ?? typeToConvert;
        if (t == typeof(DateTimeOffset))
        {
            return new DateTimeOffset(d, TimeSpan.Zero);
        }
        return d;
    }

    public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        long seconds = value switch
        {
            DateTime dateTime => (long)(dateTime.ToUniversalTime() - UnixEpoch).TotalSeconds,
            DateTimeOffset dateTimeOffset => (long)(dateTimeOffset.ToUniversalTime() - new DateTimeOffset(UnixEpoch)).TotalSeconds,
            _ => throw new JsonException("Expected date object value.")
        };

        if (seconds < 0)
        {
            throw new JsonException("Cannot convert date value that is before Unix epoch of 00:00:00 UTC on 1 January 1970.");
        }
        writer.WriteNumberValue(seconds);
    }

    public override bool CanConvert(Type objectType) =>
        objectType == typeof(DateTime) ||
        objectType == typeof(DateTime?) ||
        objectType == typeof(DateTimeOffset) ||
        objectType == typeof(DateTimeOffset?);
}
