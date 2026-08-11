namespace Morningstar.Snapshot.Domain.Models;

public class TradeCancellationMessage : IMessage
{
    public string? OriginalTradeID { get; set; }
    public long? DateTime { get; set; }
}
