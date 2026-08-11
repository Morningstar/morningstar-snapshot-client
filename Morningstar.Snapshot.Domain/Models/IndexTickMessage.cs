namespace Morningstar.Snapshot.Domain.Models;

public class IndexTickMessage : IMessage
{
    public long? PriceCalculationDateTime { get; set; }
}
