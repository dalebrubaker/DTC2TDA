using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Tests;

public class TestFixture : IDisposable
{
    private static int s_counterStart;
    private static int s_counterExit;

    /// <summary>
    ///     must be parameterless
    /// </summary>
    public TestFixture()
    {
        // Allow logging during Tests
        CreateSerilogLogger();
        var method = MethodBase.GetCurrentMethod();
        var stackTrace = Environment.StackTrace;
        Log.Verbose("Starting {counter} {classType}", s_counterStart++, GetType().Name);
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

    public void Dispose()
    {
        Log.Verbose("Exiting {counter} {classType}", s_counterExit++, GetType().Name);
        Log.CloseAndFlush();
    }
}