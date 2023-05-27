using Microsoft.AspNetCore.Http;
using NSubstitute;
using System.Text;
using System.Text.Json;

namespace MovieManagement.Functions.Test;

[TestFixture]
internal class HttpRequestMockTestHelper
{
    private MemoryStream? memoryStream;

    [TearDown]
    public void TearDown()
    {
        memoryStream?.Dispose();
    }

    protected HttpRequest GetMockedHttpRequest<T>(T dto)
    {
        var mock = Substitute.For<HttpRequest>();

        var json = JsonSerializer.Serialize(dto);
        var data = Encoding.ASCII.GetBytes(json);
        memoryStream = new MemoryStream(data);
        memoryStream.Flush();
        memoryStream.Position = 0;
        mock.Body.Returns(memoryStream);

        return mock;
    }
}
