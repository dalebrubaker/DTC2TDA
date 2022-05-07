using System;
using System.Net;
using System.Threading.Tasks;
using Domain;
using DTCClient;
using DTCPB;
using Microsoft.Extensions.Configuration;
using Serilog;
using TDAmeritradeSharpClient;
using Xunit;

namespace Tests;

public class TestFixture : IDisposable
{
    private static int s_nextServerPort = 54321;
    private static readonly object s_lock = new();
    private static int s_counterStart;
    private static int s_counterExit;

    /// <summary>
    ///     must be parameterless
    /// </summary>
    public TestFixture()
    {
        // Allow logging during Tests
        CreateSerilogLogger();
        Log.Verbose("Starting {Counter} {ClassType}", s_counterStart++, GetType().Name);
    }

    public static int NextServerPort
    {
        get
        {
            lock (s_lock)
            {
                return s_nextServerPort++;
            }
        }
    }

    public void Dispose()
    {
        Log.Verbose("Exiting {Counter} {ClassType}", s_counterExit++, GetType().Name);
        Log.CloseAndFlush();
        GC.SuppressFinalize(this);
    }

    private static void CreateSerilogLogger()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<TestFixture>()
            .Build();
        Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(configuration)
            .CreateLogger();
    }

    public static async Task<ServiceDTC> StartTestServerAsync(int port)
    {
        var client = new Client();
        await client.RequireNotExpiredTokensAsync().ConfigureAwait(false);
        var clientStream = new ClientStream(client);
        var server = new ServiceDTC(IPAddress.Loopback, port, client, clientStream);
        server.StartServer();
        Assert.NotNull(server);
        return server;
    }

    public static ClientDTC ConnectClient(int port, EncodingEnum encoding = EncodingEnum.ProtocolBuffers)
    {
        var client = new ClientDTC();
        client.StartClient("localhost", port);
        var (loginResponse, error) = client.Logon("TestClient", requestedEncoding: encoding);
        Assert.NotNull(loginResponse);
        Assert.False(error.IsError);
        return client;
    }
}