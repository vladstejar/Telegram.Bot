using System;
using System.IO;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.Serialization;

public class InputFileSerializationTests
{
    [Fact(DisplayName = "Should serialize & deserialize input file from stream")]
    public void Should_Serialize_InputFile()
    {
        const string fileName = "myFile";
        InputFileStream inputFile = new(new MemoryStream(), fileName);

        string json = Serializer.Serialize(inputFile);
        InputFileStream obj = Serializer.Deserialize<InputFileStream>(json)!;

        Assert.Equal(@$"""attach://{fileName}""", json);
        Assert.Equal(Stream.Null, obj.Content);
        Assert.Equal(fileName, obj.FileName);
        Assert.Equal(FileType.Stream, obj.FileType);
    }

    [Fact(DisplayName = "Should serialize & deserialize input file with file_id")]
    public void Should_Serialize_FileId()
    {
        const string fileId = "This-is-a-file_id";
        InputFileId inputFileId = new(fileId);

        string json = Serializer.Serialize(inputFileId);
        InputFileId? obj = Serializer.Deserialize<InputFileId>(json);

        Assert.NotNull(obj);
        Assert.Equal(@$"""{fileId}""", json);
        Assert.Equal(fileId, obj.Id);
        Assert.Equal(FileType.Id, obj.FileType);
    }

    [Fact(DisplayName = "Should serialize & deserialize input file with URL")]
    public void Should_Serialize_InputUrlFile()
    {
        Uri url = new("http://github.org/TelegramBots");
        InputFileUrl inputFileUrl = new(url);

        string json = Serializer.Serialize(inputFileUrl);
        InputFileUrl? obj = Serializer.Deserialize<InputFileUrl>(json);

        Assert.NotNull(obj);
        Assert.Equal(@$"""{url}""", json);
        Assert.Equal(url, obj.Url);
        Assert.Equal(FileType.Url, obj.FileType);
    }
}
