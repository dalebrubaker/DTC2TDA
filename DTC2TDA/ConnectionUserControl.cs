using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Domain;
using Domain.ViewModels;

// ReSharper disable LocalizableElement

namespace DTC2TDA;

public partial class ConnectionUserControl : UserControl
{
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

    private void btnStartListening_Click(object sender, EventArgs e)
    {
        btnStartListening.Enabled = false;
        btnStopListening.Enabled = true;
        _serverListening = new ServiceDTC(_ipAddress!, _viewModel!.PortListening);
        _serverListening.MessageEvent += ServerOnMessageEvent;
        _serverListening.StartServer();
        logControl1.LogMessage($"Started {_serverListening}");
    }

    private void btnStopListening_Click(object sender, EventArgs e)
    {
        btnStartListening.Enabled = true;
        btnStopListening.Enabled = false;
        _serverListening?.Dispose();
        logControl1.LogMessage($"Stopped {_serverListening}");
    }

    private void btnStartHistorical_Click(object sender, EventArgs e)
    {
        btnStartHistorical.Enabled = false;
        btnStopHistorical.Enabled = true;
        _serverHistorical = new ServiceDTC(_ipAddress!, _viewModel!.PortHistorical);
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