using System;
using System.Threading.Tasks;
using TDAmeritradeSharpClient;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

[Collection("NotParallel collection")]
public class LogonTests : IClassFixture<TestFixture>, IDisposable
{
    private readonly TestFixture _fixture;
    private readonly ITestOutputHelper _output;

    public LogonTests(TestFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }

    public void Dispose()
    {
        _output.WriteLine("Disposing");
        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task LogonResponseShouldBeCorrect()
    {
        if (!await TestFixture.IsClientAvailableAsync().ConfigureAwait(false))
        {
            // Return, don't fail, on CI machine
            return;
        }
        var port = TestFixture.NextServerPort;
        using var server = TestFixture.StartTestServerAsync(port);
        using var client = TestFixture.ConnectClient(port);
        Assert.True(client.LogonResponse.IsTradingSupported);
    }
}