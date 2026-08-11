namespace Morningstar.Snapshot.Domain.Models;

public class MidPriceMessage : IMessage
{
    public double? Price { get; set; }
    public double? PriceHigh { get; set; }
    public double? PriceLow { get; set; }
    public double? PriceClose { get; set; }
    public long? DateTime { get; set; }
}
