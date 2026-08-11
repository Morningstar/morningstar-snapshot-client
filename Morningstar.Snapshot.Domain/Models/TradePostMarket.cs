namespace Morningstar.Snapshot.Domain.Models;

public class TradePostMarket : IMessage
{
    public double? Price { get; set; }
    public int? Size { get; set; }
    public int? CumulativeVolume { get; set; }
    public int? Count { get; set; }
    public long? DateTime { get; set; }
}
