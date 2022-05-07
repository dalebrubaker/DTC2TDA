using System;
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
    public void LogonResponseShouldBeCorrect()
    {
        var port = TestFixture.NextServerPort;
        using var server = TestFixture.StartTestServerAsync(port);
        using var client = TestFixture.ConnectClient(port);
        Assert.True(client.LogonResponse.IsTradingSupported);
    }
}