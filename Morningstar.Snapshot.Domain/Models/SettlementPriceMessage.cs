using System.ComponentModel;
namespace Morningstar.Snapshot.Domain.Models;

public class SettlementPriceMessage : IMessage
{
    public double? FinalSettlementPrice { get; set; }
    public double? TodaysSettlementPrice { get; set; }
    public int? SettlementPriceType { get; set; }
    public long? SettlementPriceDateTime { get; set; }
    public int? SettlementPriceCalculationDate { get; set; }
    public double? PreviousSettlementPrice { get; set; }
    public string? SettlementPriceMethod { get; set; }
}
