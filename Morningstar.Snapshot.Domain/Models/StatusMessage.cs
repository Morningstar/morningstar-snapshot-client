namespace Morningstar.Snapshot.Domain.Models;

public class StatusMessage : IMessage
{
    public string? InstrumentPhase { get; set; }
    public long? InstrumentPhaseDateTime { get; set; }
    public int? TradingStatus { get; set; }
    public long? TradingStatusDateTime { get; set; }
}
