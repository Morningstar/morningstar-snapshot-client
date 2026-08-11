namespace Morningstar.Snapshot.Domain.Models;

public class TradeCorrectionMessage : IMessage
{
    public double? CorrectedTradePrice { get; set; }
    public int? CorrectedTradeSize { get; set; }
    public string? OriginalTradeID { get; set; }
    public long? DateTime { get; set; }
    public string? CorrectedTradeConditions { get; set; }
}
