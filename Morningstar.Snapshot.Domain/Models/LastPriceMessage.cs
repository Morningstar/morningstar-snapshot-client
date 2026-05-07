namespace Morningstar.Snapshot.Domain.Models;

public class LastPriceMessage : IMessage
{
    public double? Price { get; set; }
    public int? Size { get; set; }
    public long? PricePublishDateTime { get; set; }
}
