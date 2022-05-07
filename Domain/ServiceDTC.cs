using System.Net;
using System.Reflection;
using DTCCommon;
using DTCPB;
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
        if (messageProto.IsExtended)
        {
            return HandleRequestExtendedAsync(clientHandler, messageProto);
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

            case DTCMessageType.HistoricalPriceDataRequest:
                var historicalPriceDataRequest = (HistoricalPriceDataRequest)message;
                // HistoricalPriceDataResponseHeader.UseZLibCompressionBool = historicalPriceDataRequest.UseZLibCompressionBool;
                // clientHandler.SendResponse(DTCMessageType.HistoricalPriceDataResponseHeader, HistoricalPriceDataResponseHeader);
                // var numSent = 0;
                // for (int i = 0; i < HistoricalPriceDataRecordResponses.Count; i++)
                // {
                //     var historicalPriceDataRecordResponse = HistoricalPriceDataRecordResponses[i];
                //     if (historicalPriceDataRecordResponse.StartDateTime >= historicalPriceDataRequest.StartDateTime)
                //     {
                //         numSent++;
                //         clientHandler.SendResponse(DTCMessageType.HistoricalPriceDataRecordResponse, historicalPriceDataRecordResponse);
                //     }
                // }

                // This demonstrates the DTC rule that an empty record may be sent with IsFinalRecordBool.HistoricalPriceDataRecordResponses.Count - 1
                //  Probably better design IMHO to set IsFinalRecordBool when i == HistoricalPriceDataRecordResponses.Count - 1
                var historicalPriceDataRecordResponseFinal = new HistoricalPriceDataRecordResponse();
                historicalPriceDataRecordResponseFinal.IsFinalRecordBool = true;
                clientHandler.SendResponse(DTCMessageType.HistoricalPriceDataRecordResponse, historicalPriceDataRecordResponseFinal);
                ;
                if (historicalPriceDataRequest.UseZLibCompressionBool)
                {
                    clientHandler.EndZippedHistorical();
                }

                // To be like SierraChart you can uncomment the following line to make this a historical client with one-time use 
                // clientHandler.Dispose();
                break;
            case DTCMessageType.MarketDataRequest:
                var marketDataRequest = (MarketDataRequest)message;
                switch (marketDataRequest.RequestAction)
                {
                    case RequestActionEnum.RequestActionUnset:
                        break;
                    case RequestActionEnum.Subscribe:
                        // SendSnapshot(clientHandler);
                        // SendMarketData(clientHandler, marketDataRequest);
                        break;
                    case RequestActionEnum.Unsubscribe:
                        // stop sending data
                        break;
                    case RequestActionEnum.Snapshot:
                        // SendSnapshot(clientHandler);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case DTCMessageType.SecurityDefinitionForSymbolRequest:
                var securityDefinitionForSymbolRequest = (SecurityDefinitionForSymbolRequest)message;
                var securityDefinitionResponse = new SecurityDefinitionResponse
                {
                    RequestID = securityDefinitionForSymbolRequest.RequestID,
                    Symbol = securityDefinitionForSymbolRequest.Symbol,
                    MinPriceIncrement = 0.25f,
                    Description = "Description must not be empty."
                };
                //s_logger.Debug("Sending SecurityDefinitionResponse");
                clientHandler.SendResponse(DTCMessageType.SecurityDefinitionResponse, securityDefinitionResponse);
                break;
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
            case DTCMessageType.TradeAccountsRequest:
                break;
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
            case DTCMessageType.MarketDepthRequest:
            case DTCMessageType.MarketOrdersRequest:
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
        return Task.CompletedTask;
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