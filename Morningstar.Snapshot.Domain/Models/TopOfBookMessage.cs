namespace Morningstar.Snapshot.Domain.Models;

public class TopOfBookMessage : IMessage
{
    public double? AskPrice { get; set; }
    public int? AskSize { get; set; }
    public long? AskPriceDateTime { get; set; }
    public int? AskConditionFlag { get; set; }
    public int? AskExchange { get; set; }
    public double? BidPrice { get; set; }
    public int? BidSize { get; set; }
    public long? BidPriceDateTime { get; set; }
    public int? BidConditionFlag { get; set; }
    public int? BidExchange { get; set; }
    public double? AskPriceClose { get; set; }
    public double? BidPriceClose { get; set; }
}
