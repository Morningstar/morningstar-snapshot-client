namespace Morningstar.Snapshot.Domain.Models;

public class TradeMessage : IMessage
{
    public TradePostMarket TradePostMarket { get; set; }
    public TradePreMarket TradePreMarket { get; set; }
    public TradeRegulatory TradeRegulatory { get; set; }
    public TradePrice TradePrice { get; set; }
}
