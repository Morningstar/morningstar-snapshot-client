using System.ComponentModel;

namespace Morningstar.Snapshot.Domain.Models;

[DisplayName("Close")]
public class CloseMessage : IMessage
{
    public double? ClosePrice { get; set; }
    public long? ClosePriceDateTime { get; set; }
    public double? UnadjustedPreviousClosePrice { get; set; }
    public double? VendorProvidedAdjustedPreviousClosePrice { get; set; }
}
