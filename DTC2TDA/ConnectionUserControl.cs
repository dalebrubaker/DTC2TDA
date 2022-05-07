using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Authentication;
using System.Text.Json;
using Domain;
using Domain.ViewModels;
using Serilog;
using TDAmeritradeSharpClient;

// ReSharper disable LocalizableElement

namespace DTC2TDA;

public partial class ConnectionUserControl : UserControl
{
    private static readonly ILogger s_logger = Log.ForContext(MethodBase.GetCurrentMethod()?.DeclaringType!);

    private IPAddress? _ipAddress;
    private ServiceDTC? _serverHistorical;
    private ServiceDTC? _serverListening;
    private ConnectionUserControlViewModel? _viewModel;

    public ConnectionUserControl()
    {
        InitializeComponent();
    }

    private string ViewModelPath => Path.Combine(Program.UserSettingsDirectory, $"{GetType().Name}.json");

    private void ConnectionUserControl_Load(object sender, EventArgs e)
    {
        if (DesignMode)
        {
            return;
        }
        LoadConfig();
        _ipAddress = SetIpAddress();
        connectionUserControlViewModelBindingSource.DataSource = _viewModel;
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        if (DesignMode)
        {
            return;
        }
        SaveConfig();
        base.OnHandleDestroyed(e);
    }

    private IPAddress? SetIpAddress()
    {
        var serverName = Environment.MachineName;
        lblServerName.Text = $"Server Name: {serverName}";
        var hostEntry = Dns.GetHostEntry(serverName);
        var ipAddress = hostEntry.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
        lblServerIPAddress.Text = $"Server IP Address: {ipAddress}";
        ipAddress = string.Equals(txtServer.Text.Trim(), "localhost", StringComparison.OrdinalIgnoreCase) ? IPAddress.Loopback : ipAddress;
        lblUsingIpAddress.Text = $"Using IP Address: {ipAddress}";
        return ipAddress;
    }

    private async void btnStartListening_Click(object sender, EventArgs e)
    {
        btnStartListening.Enabled = false;
        btnStopListening.Enabled = true;
        var tdaClient = await GetValidatedClientAsync();
        if (tdaClient == null)
        {
            btnStartListening.Enabled = true;
            btnStopListening.Enabled = false;
            return;
        }
        var tdaClientStreaming = new ClientStream(tdaClient);
        _serverListening = new ServiceDTC(_ipAddress!, _viewModel!.PortListening, tdaClient, tdaClientStreaming);
        _serverListening.MessageEvent += ServerOnMessageEvent;
        _serverListening.StartServer();
        logControl1.LogMessage($"Started {_serverListening}");
    }

    /// <summary>
    /// Return a valid client, or null after show message box if error
    /// </summary>
    /// <returns></returns>
    private static async Task<Client?> GetValidatedClientAsync()
    {
        var tdaClient = new Client();
        try
        {
            await tdaClient.RequireNotExpiredTokensAsync();
        }
        catch (AuthenticationException)
        {
            MessageBox.Show("Not authenticated. Authenticate first, using the Authentication tab.");
            return null;
        }
        catch (Exception ex)
        {
            s_logger.Error(ex, "{Message}", ex.Message);
            MessageBox.Show($"Unexpected error: {ex.Message}");
            return null;
        }
        return tdaClient;
    }

    private void btnStopListening_Click(object sender, EventArgs e)
    {
        btnStartListening.Enabled = true;
        btnStopListening.Enabled = false;
        _serverListening?.Dispose();
        logControl1.LogMessage($"Stopped {_serverListening}");
    }

    private async void btnStartHistorical_Click(object sender, EventArgs e)
    {
        btnStartHistorical.Enabled = false;
        btnStopHistorical.Enabled = true;
        var tdaClient = await GetValidatedClientAsync();
        if (tdaClient == null)
        {
            btnStartHistorical.Enabled = true;
            btnStopHistorical.Enabled = false;
            return;
        }
        var tdaClientStreaming = new ClientStream(tdaClient);
        _serverHistorical = new ServiceDTC(_ipAddress!, _viewModel!.PortHistorical, tdaClient, tdaClientStreaming);
        _serverHistorical.MessageEvent += ServerOnMessageEvent;
        _serverHistorical.StartServer();
        logControl1.LogMessage($"Started {_serverHistorical}");
    }

    private void btnStopHistorical_Click(object sender, EventArgs e)
    {
        btnStartHistorical.Enabled = true;
        btnStopHistorical.Enabled = false;
        _serverHistorical?.Dispose();
        logControl1.LogMessage($"Stopped {_serverHistorical}");
    }

    private void txtServer_Leave(object sender, EventArgs e)
    {
        SetIpAddress();
    }

    private void LoadConfig()
    {
        if (File.Exists(ViewModelPath))
        {
            var json = File.ReadAllText(ViewModelPath);
            _viewModel = JsonSerializer.Deserialize<ConnectionUserControlViewModel>(json);
        }
        _viewModel ??= new ConnectionUserControlViewModel
        {
            PortHistorical = 49998,
            PortListening = 49999,
            ServerName = "localhost"
        };
    }

    private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _serverListening?.Dispose();
        _serverHistorical?.Dispose();
        SaveConfig();
    }

    private void SaveConfig()
    {
        var json = JsonSerializer.Serialize(_viewModel);
        File.WriteAllText(ViewModelPath, json);
    }

    private void ServerOnMessageEvent(object? sender, string message)
    {
        logControl1.LogMessage(message);
    }
}