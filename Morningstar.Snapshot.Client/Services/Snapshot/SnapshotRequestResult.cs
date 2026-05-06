using Morningstar.Snapshot.Domain.Contracts;

namespace Morningstar.Snapshot.Client.Services.Snapshot;

public class SnapshotRequestResult
{
    public SnapshotResponse ApiResponse { get; set; } = null!;
}
