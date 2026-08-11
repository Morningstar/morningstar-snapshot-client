namespace Morningstar.Snapshot.Domain.Models;

public class TradePrice
{
    public double? Price { get; set; }
    public int? Size { get; set; }
    public long? ExecutionDateTime { get; set; }
    public string? Conditions { get; set; }
    public string? IdentificationCode { get; set; }
    public long? PublishDateTime { get; set; }
    public string? ExecutionVenue { get; set; }
    public string? ExecutionCurrency { get; set; }
}
