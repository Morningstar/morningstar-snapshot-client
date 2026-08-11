using System.ComponentModel;

namespace Morningstar.Snapshot.Domain.Models;

[DisplayName("Auction")]
public class AuctionMessage : IMessage
{
    public double? IndicativeAuctionPrice { get; set; }
    public int? IndicativeAuctionSize { get; set; }
    public long? ImbalanceSize { get; set; }
    public string? ImbalanceSide { get; set; }
    public string? AuctionType { get; set; }
    public int? AuctionDate { get; set; }
}
