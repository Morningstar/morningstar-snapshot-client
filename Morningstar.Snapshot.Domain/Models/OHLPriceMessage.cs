namespace Morningstar.Snapshot.Domain.Models;

public class OHLPriceMessage : IMessage
{
    public double? OpenPrice { get; set; }
    public long? OpenPriceDateTime { get; set; }
    public double? HighPrice { get; set; }
    public long? HighPriceDateTime { get; set; }
    public double? LowPrice { get; set; }
    public long? LowPriceDateTime { get; set; }
}
