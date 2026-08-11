using System.ComponentModel;

namespace Morningstar.Snapshot.Domain.Models;

[DisplayName("AggregateSummary")]
public class AggregateSummaryMessage : IMessage
{
    public int? TradeCount { get; set; }
    public long? CumulativeVolume { get; set; }
    public double? VWAP { get; set; }
    public int? Openinterest { get; set; }
    public long? OpeninterestDateTime { get; set; }
    public double? Turnover { get; set; }
}
