using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

[Collection("NotParallel collection")]
public class AccountTests : IClassFixture<TestFixture>, IDisposable
{
    private readonly ITestOutputHelper _output;

    public AccountTests(ITestOutputHelper output)
    {
        _output = output;
    }

    public void Dispose()
    {
        _output.WriteLine("Disposing");
        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task GetTradeAccountsTest()
    {
        if (!await TestFixture.IsClientAvailableAsync().ConfigureAwait(false))
        {
            // Return, don't fail, on CI machine
            return;
        }
        var port = TestFixture.NextServerPort;
        using var server = TestFixture.StartTestServerAsync(port);
        using var client = TestFixture.ConnectClient(port);
        var accountNames = client.GetTradeAccounts();
        Assert.NotEmpty(accountNames);
    }
}