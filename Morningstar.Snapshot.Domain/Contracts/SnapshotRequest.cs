namespace Morningstar.Snapshot.Domain.Contracts;

public record SnapshotRequest
{
    /// <summary>
    /// A list of Morningstar Performance Ids.
    /// </summary>    
    public InvestmentsRequest Investments { get; set; } = null!;

    /// <summary>
    /// A list of event types to subscribe to.
    /// 

    /// </summary>
    public List<string> EventTypes { get; set; } = null!;
}
