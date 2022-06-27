using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot.Requests;
using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.Requests.Getting_updates;

public class SetWebhookRequestTest
{
    [Theory]
    [ClassData(typeof(SetWebhookRequest_Data))]
    public async Task Test_SetWebhookRequest_Theory(string expectedResult, SetWebhookRequest setWebhookRequest)
    {
        HttpContent content = setWebhookRequest.ToHttpContent()!;

        /*
         * ToDo: MultipartFormDataContent test
        if (content is MultipartFormDataContent mfdc) {
            foreach (HttpContent part in mfdc) {
                if (part is StringContent) {
                    Assert.Equal("url", part.Headers.ContentDisposition.Name);
                }
            }
        }
        */

        string result = await content.ReadAsStringAsync();

        Assert.Equal(expectedResult, result, ignoreLineEndingDifferences: true, ignoreWhiteSpaceDifferences: true);
    }
}

public class SetWebhookRequest_Data : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] {
            """
            {"url":"https://localhost/api/updates"}
            """,
            new Bot.Requests.SetWebhookRequest(url: "https://localhost/api/updates")};

        /*
         * ToDo: MultipartFormDataContent test
        yield return new object[] {
            """
            {"url":"https://localhost/api/updates","certificate":"127.0.0.1"}
            """,
            new SetWebhookRequest(url: "https://localhost/api/updates")
            {
                Certificate = new(content: GetCertificate(),"my_certificate.pem"),
            } };
        */

        yield return new object[] {
            """
            {"url":"https://localhost/api/updates","ip_address":"127.0.0.1"}
            """,
            new Bot.Requests.SetWebhookRequest(url: "https://localhost/api/updates")
            {
                IpAddress = "127.0.0.1",
            } };

        yield return new object[] {
            """
            {"url":"https://localhost/api/updates","max_connections":100}
            """,
            new Bot.Requests.SetWebhookRequest(url: "https://localhost/api/updates")
            {
                MaxConnections = 100,
            } };

        yield return new object[] {
            """
            {"url":"https://localhost/api/updates","allowed_updates":[]}
            """,
            new Bot.Requests.SetWebhookRequest(url: "https://localhost/api/updates")
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
            } };

        yield return new object[] {
            """
            {"url":"https://localhost/api/updates","allowed_updates":["message"]}
            """,
            new Bot.Requests.SetWebhookRequest(url: "https://localhost/api/updates")
            {
                AllowedUpdates = new[]{ UpdateType.Message },
            } };

        yield return new object[] {
            """
            {"url":"https://localhost/api/updates","drop_pending_updates":true}
            """,
            new Bot.Requests.SetWebhookRequest(url: "https://localhost/api/updates")
            {
                DropPendingUpdates = true,
            } };

        yield return new object[] {
            """
            {"url":"https://localhost/api/updates","secret_token":"S3cR3tT0k3n"}
            """,
            new Bot.Requests.SetWebhookRequest(url: "https://localhost/api/updates")
            {
                SecretToken = "S3cR3tT0k3n",
            } };

    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /*
     * ToDo: MultipartFormDataContent test
    private const string certificate = """
        -----BEGIN CERTIFICATE-----
        MIICWjCCAcMCAgGlMA0GCSqGSIb3DQEBBAUAMHUxCzAJBgNVBAYTAlVTMRgwFgYDVQQKEw9HVEUg
        Q29ycG9yYXRpb24xJzAlBgNVBAsTHkdURSBDeWJlclRydXN0IFNvbHV0aW9ucywgSW5jLjEjMCEG
        A1UEAxMaR1RFIEN5YmVyVHJ1c3QgR2xvYmFsIFJvb3QwHhcNOTgwODEzMDAyOTAwWhcNMTgwODEz
        MjM1OTAwWjB1MQswCQYDVQQGEwJVUzEYMBYGA1UEChMPR1RFIENvcnBvcmF0aW9uMScwJQYDVQQL
        Ex5HVEUgQ3liZXJUcnVzdCBTb2x1dGlvbnMsIEluYy4xIzAhBgNVBAMTGkdURSBDeWJlclRydXN0
        IEdsb2JhbCBSb290MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCVD6C28FCc6HrHiM3dFw4u
        sJTQGz0O9pTAipTHBsiQl8i4ZBp6fmw8U+E3KHNgf7KXUwefU/ltWJTSr41tiGeA5u2ylc9yMcql
        HHK6XALnZELn+aks1joNrI1CqiQBOeacPwGFVw1Yh0X404Wqk2kmhXBIgD8SFcd5tB8FLztimQID
        AQABMA0GCSqGSIb3DQEBBAUAA4GBAG3rGwnpXtlR22ciYaQqPEh346B8pt5zohQDhT37qw4wxYMW
        M4ETCJ57NE7fQMh017l93PR2VX2bY1QY6fDq81yx2YtCHrnAlU66+tXifPVoYb+O7AWXX1uw16OF
        NMQkpw0PlZPvy5TYnh+dXIVtx6quTx8itc2VrbqnzPmrC3p/
        -----END CERTIFICATE-----
        """;

    private Stream GetCertificate()
    {
        MemoryStream stream = new();
        StreamWriter writer = new(stream);
        writer.Write(certificate);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
    */
}
