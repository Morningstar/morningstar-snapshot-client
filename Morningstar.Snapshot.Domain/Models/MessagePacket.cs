using Morningstar.Snapshot.Domain.Models.Enums;
using Newtonsoft.Json;

namespace Morningstar.Snapshot.Domain.Models;

public class MessagePacket<T> where T : IMessage
{
    public EventType EventType { get; set; }
    public string? PerformanceId { get; set; }
    public long? PublishTime { get; set; }
    public long? AcknowledgedTime { get; set; }
    public long? SequenceNumber { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public T Message { get; set; }
}