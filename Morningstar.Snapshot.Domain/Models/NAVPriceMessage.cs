namespace Morningstar.Snapshot.Domain.Models;

public class NAVPriceMessage : IMessage
{
    public double? ExchangeNAV { get; set; }
    public long? NAVDateTime { get; set; }
}
