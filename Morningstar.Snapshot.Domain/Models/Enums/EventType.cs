namespace Morningstar.Snapshot.Domain.Models.Enums;

public enum EventType
{
    Unknown = 0,
    AggregateSummary = 1,
    Auction = 2,
    Close = 3,
    IndexTick = 5,
    LastPrice = 6,
    MidPrice = 8,
    NAVPrice = 9,
    OHLPrice = 10,
    SettlementPrice = 12,
    Status = 14,
    TopOfBook = 15,
    TradePostMarket = 16,
    TradePreMarket = 17,
    TradeCancellation = 18,
    TradeCorrection = 19,
    Trade = 20,
}
