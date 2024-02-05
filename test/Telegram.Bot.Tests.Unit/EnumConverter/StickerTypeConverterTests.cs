using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class StickerTypeConverterTests
{
    [Fact]
    public void Should_Verify_All_StickerType_Members()
    {
        List<string> stickerTypeMembers = Enum
            .GetNames<StickerType>()
            .OrderBy(x => x)
            .ToList();
        List<string> stickerTypeDataMembers = new StickerTypeData()
            .Select(x => Enum.GetName(typeof(StickerType), x[0]))
            .OrderBy(x => x)
            .ToList()!;

        Assert.Equal(stickerTypeMembers.Count, stickerTypeDataMembers.Count);
        Assert.Equal(stickerTypeMembers, stickerTypeDataMembers);
    }


    [Theory]
    [ClassData(typeof(StickerTypeData))]
    public void Should_Convert_StickerType_To_String(StickerType stickerType, string value)
    {
        Sticker sticker = new() { Type = stickerType };
        string expectedResult = @$"{{""type"":""{value}""}}";

        string result = Serializer.Serialize(sticker);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [ClassData(typeof(StickerTypeData))]
    public void Should_Convert_String_To_StickerType(StickerType stickerType, string value)
    {
        Sticker expectedResult = new() { Type = stickerType };
        string jsonData = @$"{{""type"":""{value}""}}";

        Sticker result = Serializer.Deserialize<Sticker>(jsonData)!;

        Assert.Equal(expectedResult.Type, result.Type);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_StickerType()
    {
        string jsonData = @$"{{""type"":""{int.MaxValue}""}}";

        Sticker result = Serializer.Deserialize<Sticker>(jsonData)!;

        Assert.Equal((StickerType)0, result.Type);
    }

    [Fact]
    public void Should_Throw_NotSupportedException_For_Incorrect_StickerType()
    {
        Sticker sticker = new() { Type = (StickerType)int.MaxValue };

#if NET8_0_OR_GREATER
        Assert.Throws<JsonException>(() => Serializer.Serialize(sticker));
#else
        Assert.Throws<NotSupportedException>(() => Serializer.Serialize(sticker));
#endif
    }

#if !NET8_0_OR_GREATER
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
    [DataContract]
    class Sticker
    {
        [DataMember(IsRequired = true)]
        public StickerType Type { get; set; }
    }

    private class StickerTypeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [StickerType.Regular, "regular"];
            yield return [StickerType.Mask, "mask"];
            yield return [StickerType.CustomEmoji, "custom_emoji"];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
