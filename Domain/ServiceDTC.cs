using System.Net;
using System.Reflection;
using DTCCommon;
using DTCServer;
using Serilog;

namespace Domain;

public sealed class ServiceDTC : ListenerDTC
{
    private static readonly ILogger s_logger = Log.ForContext(MethodBase.GetCurrentMethod()!.DeclaringType!);

    public ServiceDTC(IPAddress ipAddress, int port) : base(ipAddress, port)
    {
    }

    protected override Task HandleRequestAsync(ClientHandlerDTC clientHandler, MessageProto messageProto)
    {
        throw new NotImplementedException();
    }

    #region events

    public event EventHandler<string>? MessageEvent;

    private void OnMessage(string message)
    {
        var temp = MessageEvent;
        temp?.Invoke(this, message);
    }

    #endregion events
}