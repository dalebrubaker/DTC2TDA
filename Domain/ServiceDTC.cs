using System.Net;
using System.Reflection;
using DTCCommon;
using DTCPB;
using DTCServer;
using Serilog;
using TDAmeritradeSharpClient;

namespace Domain;

public sealed class ServiceDTC : ListenerDTC
{
    private readonly Client _client;
    private readonly ClientStream _clientStream;
    private static readonly ILogger s_logger = Log.ForContext(MethodBase.GetCurrentMethod()!.DeclaringType!);

    public ServiceDTC(IPAddress ipAddress, int port, Client client, ClientStream clientStream) : base(ipAddress, port)
    {
        _client = client;
        _clientStream = clientStream;
    }

    protected override async Task HandleRequestAsync(ClientHandlerDTC clientHandler, MessageProto messageProto)
    {
        if (messageProto.IsExtended)
        {
            await HandleRequestExtendedAsync(clientHandler, messageProto).ConfigureAwait(false);
            return;
        }
        var messageType = messageProto.MessageType;
        var message = messageProto.Message;
        switch (messageType)
        {
            case DTCMessageType.Heartbeat:
            case DTCMessageType.Logoff:
            case DTCMessageType.EncodingRequest:
                {
                    // This is informational only. Request already has been handled by the clientHandler
                    break;
                }
            case DTCMessageType.LogonRequest:
                // Documented at See https://dtcprotocol.org/index.php?page=doc/DTCMessages_AuthenticationConnectionMonitoringMessages.php#Messages-LOGON_RESPONSE
                var logonRequest = (LogonRequest)message;
                var logonResponse = new LogonResponse
                {
                    ProtocolVersion = logonRequest.ProtocolVersion,
                    Result = LogonStatusEnum.LogonSuccess,
                    ServerName = "DTC2TDA",
                    TradingIsSupported = 1u,
                    OCOOrdersSupported = 1u,
                    OrderCancelReplaceSupported = 1u,
                    SecurityDefinitionsSupported = 1u,
                    HistoricalPriceDataSupported = 1u,
                    ResubscribeWhenMarketDataFeedAvailable = 1u,
                    MarketDepthIsSupported = 1u,
                    BracketOrdersSupported = 1u,
                    MarketDataSupported = 1u

                    // Uncomment the following line to be like SierraChart. Not necessary forDTCSharp
                    //OneHistoricalPriceDataRequestPerConnection = 1u
                };
                clientHandler.SendResponse(DTCMessageType.LogonResponse, logonResponse);
                break;
            case DTCMessageType.TradeAccountsRequest:
                var tradeAccountsRequest = (TradeAccountsRequest)message;
                var accounts = (await _client.GetAccountsAsync().ConfigureAwait(false)).ToList();
                for (var i = 0; i < accounts.Count; i++)
                {
                    var account = accounts[i];
                    var tradeAccountResponse = new TradeAccountResponse
                    {
                        TotalNumberMessages = accounts.Count,
                        MessageNumber = i + 1,
                        TradeAccount = account.SecuritiesAccount.AccountId, // TODO use DisplayName if that option is set
                        RequestID = tradeAccountsRequest.RequestID
                    };
                    clientHandler.SendResponse(DTCMessageType.TradeAccountResponse, tradeAccountResponse);
                }
                break;
            case DTCMessageType.HistoricalPriceDataRequest:
            case DTCMessageType.MarketDataRequest:
            case DTCMessageType.SecurityDefinitionForSymbolRequest:
            case DTCMessageType.MarketDataReject:
            case DTCMessageType.MarketDataSnapshot:
            case DTCMessageType.MarketDataSnapshotInt:
            case DTCMessageType.MarketDataUpdateTrade:
            case DTCMessageType.MarketDataUpdateTradeCompact:
            case DTCMessageType.MarketDataUpdateTradeInt:
            case DTCMessageType.MarketDataUpdateLastTradeSnapshot:
            case DTCMessageType.MarketDataUpdateTradeWithUnbundledIndicator:
            case DTCMessageType.MarketDataUpdateTradeWithUnbundledIndicator2:
            case DTCMessageType.MarketDataUpdateTradeNoTimestamp:
            case DTCMessageType.MarketDataUpdateBidAsk:
            case DTCMessageType.MarketDataUpdateBidAskCompact:
            case DTCMessageType.MarketDataUpdateBidAskNoTimestamp:
            case DTCMessageType.MarketDataUpdateBidAskInt:
            case DTCMessageType.MarketDataUpdateSessionOpen:
            case DTCMessageType.MarketDataUpdateSessionOpenInt:
            case DTCMessageType.MarketDataUpdateSessionHigh:
            case DTCMessageType.MarketDataUpdateSessionHighInt:
            case DTCMessageType.MarketDataUpdateSessionLow:
            case DTCMessageType.MarketDataUpdateSessionLowInt:
            case DTCMessageType.MarketDataUpdateOpenInterest:
            case DTCMessageType.MarketDataUpdateSessionSettlement:
            case DTCMessageType.MarketDataUpdateSessionSettlementInt:
            case DTCMessageType.MarketDataUpdateSessionNumTrades:
            case DTCMessageType.MarketDataUpdateTradingSessionDate:
            case DTCMessageType.MarketDepthReject:
            case DTCMessageType.MarketDepthSnapshotLevel:
            case DTCMessageType.MarketDepthSnapshotLevelInt:
            case DTCMessageType.MarketDepthSnapshotLevelFloat:
            case DTCMessageType.MarketDepthUpdateLevel:
            case DTCMessageType.MarketDepthUpdateLevelFloatWithMilliseconds:
            case DTCMessageType.MarketDepthUpdateLevelNoTimestamp:
            case DTCMessageType.MarketDepthUpdateLevelInt:
            case DTCMessageType.MarketDataFeedStatus:
            case DTCMessageType.MarketDataFeedSymbolStatus:
            case DTCMessageType.TradingSymbolStatus:
            case DTCMessageType.SubmitNewSingleOrder:
            case DTCMessageType.SubmitNewSingleOrderInt:
            case DTCMessageType.SubmitNewOcoOrder:
            case DTCMessageType.SubmitNewOcoOrderInt:
            case DTCMessageType.SubmitFlattenPositionOrder:
            case DTCMessageType.CancelOrder:
            case DTCMessageType.CancelReplaceOrder:
            case DTCMessageType.CancelReplaceOrderInt:
            case DTCMessageType.OpenOrdersRequest:
            case DTCMessageType.OpenOrdersReject:
            case DTCMessageType.OrderUpdate:
            case DTCMessageType.HistoricalOrderFillsRequest:
            case DTCMessageType.HistoricalOrderFillsReject:
            case DTCMessageType.CurrentPositionsRequest:
            case DTCMessageType.CurrentPositionsReject:
            case DTCMessageType.PositionUpdate:
            case DTCMessageType.ExchangeListRequest:
            case DTCMessageType.SymbolsForExchangeRequest:
            case DTCMessageType.UnderlyingSymbolsForExchangeRequest:
            case DTCMessageType.SymbolsForUnderlyingRequest:
            case DTCMessageType.SymbolSearchRequest:
            case DTCMessageType.SecurityDefinitionReject:
            case DTCMessageType.AccountBalanceRequest:
            case DTCMessageType.AccountBalanceReject:
            case DTCMessageType.AccountBalanceUpdate:
            case DTCMessageType.AccountBalanceAdjustment:
            case DTCMessageType.AccountBalanceAdjustmentComplete:
            case DTCMessageType.HistoricalAccountBalancesRequest:
            case DTCMessageType.UserMessage:
            case DTCMessageType.GeneralLogMessage:
            case DTCMessageType.AlertMessage:
            case DTCMessageType.JournalEntryAdd:
            case DTCMessageType.JournalEntriesRequest:
            case DTCMessageType.HistoricalMarketDepthDataRequest:
            case DTCMessageType.MarketDepthRequest:
            case DTCMessageType.MarketOrdersRequest:
                var generalLogMessage = new GeneralLogMessage
                {
                    MessageText = $"Not supported yet: {message}"
                };
                clientHandler.SendResponse(DTCMessageType.GeneralLogMessage, generalLogMessage);
                
                throw new NotImplementedException($"{messageType}");
            case DTCMessageType.MessageTypeUnset:
            case DTCMessageType.LogonResponse:
            case DTCMessageType.EncodingResponse:
            case DTCMessageType.HistoricalOrderFillResponse:
            case DTCMessageType.TradeAccountResponse:
            case DTCMessageType.ExchangeListResponse:
            case DTCMessageType.SecurityDefinitionResponse:
            case DTCMessageType.AccountBalanceAdjustmentReject:
            case DTCMessageType.HistoricalAccountBalancesReject:
            case DTCMessageType.HistoricalAccountBalanceResponse:
            case DTCMessageType.JournalEntriesReject:
            case DTCMessageType.JournalEntryResponse:
            case DTCMessageType.HistoricalPriceDataResponseHeader:
            case DTCMessageType.HistoricalPriceDataReject:
            case DTCMessageType.HistoricalPriceDataRecordResponse:
            case DTCMessageType.HistoricalPriceDataTickRecordResponse:
            case DTCMessageType.HistoricalPriceDataRecordResponseInt:
            case DTCMessageType.HistoricalPriceDataTickRecordResponseInt:
            case DTCMessageType.HistoricalPriceDataResponseTrailer:
            case DTCMessageType.HistoricalMarketDepthDataResponseHeader:
            case DTCMessageType.HistoricalMarketDepthDataReject:
            case DTCMessageType.HistoricalMarketDepthDataRecordResponse:
                throw new NotSupportedException($"Unexpected request {messageType} in {GetType().Name}.{nameof(HandleRequestAsync)}");
            case DTCMessageType.MarketDataUpdateBidAskFloatWithMicroseconds:
            case DTCMessageType.MarketDataUpdateSessionVolume:
            case DTCMessageType.MarketOrdersReject:
            case DTCMessageType.MarketOrdersAdd:
            case DTCMessageType.MarketOrdersModify:
            case DTCMessageType.MarketOrdersRemove:
            case DTCMessageType.MarketOrdersSnapshotMessageBoundary:
            case DTCMessageType.AddCorrectingOrderFill:
            case DTCMessageType.CorrectingOrderFillResponse:
            default:
                throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
        }
        var msg = $"{messageType}:{message}";
        OnMessage(msg);
    }

    private Task HandleRequestExtendedAsync(ClientHandlerDTC clientHandler, MessageProto messageProto)
    {
        switch (messageProto.MessageTypeExtended)
        {
            case DTCSharpMessageType.Unset:
            default:
                throw new ArgumentOutOfRangeException(messageProto.MessageType.ToString());
        }
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