namespace Morningstar.Snapshot.Domain.Models.Snapshot;

public class Message
{
    public required List<InvestmentMessage> Investments { get; set; }
    public required string Type { get; set; }
}
