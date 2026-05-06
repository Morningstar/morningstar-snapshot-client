using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Morningstar.Snapshot.Client.Clients;
using Morningstar.Snapshot.Client.Services;
using Morningstar.Snapshot.Client.Services.Snapshot;
using Morningstar.Snapshot.Domain.Config;
using Morningstar.Snapshot.Domain.Contracts;
using Morningstar.Snapshot.Domain.Models;
using System.Net;
using TechTalk.SpecFlow;

namespace Morningstar.Snapshot.Client.BDD.Tests.StepDefinitions;

[Binding]
public class SnapshotStepDefinitions
{
    private readonly Mock<ISnapshotApiClient> apiClientMock = new();
    private SnapshotRequest request = null!;
    private SnapshotResponse response = null!;
    private SnapshotService service = null!;

    [BeforeScenario]
    public void BeforeScenario()
    {
        apiClientMock.Reset();

        var appConfig = Options.Create(new AppConfig { SnapshotApiBaseAddress = "https://api.example.com" });
        var endpointConfig = Options.Create(new EndpointConfig { Level1UrlAddress = "snapshot/v1/level1" });
        var factory = new SnapshotFactory(apiClientMock.Object, appConfig, endpointConfig);

        service = new SnapshotService(factory, NullLogger<SnapshotService>.Instance);
    }

    [Given(@"I have a snapshot request for ""(.*)"" with event type ""(.*)""")]
    public void GivenIHaveASnapshotRequestForWithEventType(string performanceId, string eventType)
    {
        request = new SnapshotRequest
        {
            Investments = new InvestmentsRequest { IdType = "PerformanceId", Ids = [performanceId] },
            EventTypes = [eventType]
        };

        apiClientMock
            .Setup(c => c.RequestSnapshotAsync(It.IsAny<SnapshotRequest>(), It.IsAny<string>()))
            .ReturnsAsync(new SnapshotResponse
            {
                StatusCode = HttpStatusCode.OK,
                Data = new DataContainer
                {
                    Realtime =
                    [
                        new InstrumentData
                        {
                            PerformanceId = performanceId,
                            Events = new SortedDictionary<string, EventData>(StringComparer.Ordinal)
                            {
                                [eventType] = new EventData { SequenceNumber = 1 }
                            }
                        }
                    ]
                },
                MetaData = new MetaData { RequestId = Guid.NewGuid().ToString(), Time = DateTime.UtcNow.ToString("o") }
            });
    }

    [Given(@"I have a snapshot request for ""(.*)"" with event types ""(.*)"" and ""(.*)""")]
    public void GivenIHaveASnapshotRequestForWithEventTypes(string performanceId, string eventType1, string eventType2)
    {
        request = new SnapshotRequest
        {
            Investments = new InvestmentsRequest { IdType = "PerformanceId", Ids = [performanceId] },
            EventTypes = [eventType1, eventType2]
        };

        apiClientMock
            .Setup(c => c.RequestSnapshotAsync(It.IsAny<SnapshotRequest>(), It.IsAny<string>()))
            .ReturnsAsync(new SnapshotResponse
            {
                StatusCode = HttpStatusCode.OK,
                Data = new DataContainer
                {
                    Realtime =
                    [
                        new InstrumentData
                        {
                            PerformanceId = performanceId,
                            Events = new SortedDictionary<string, EventData>(StringComparer.Ordinal)
                            {
                                [eventType1] = new EventData { SequenceNumber = 1 },
                                [eventType2] = new EventData { SequenceNumber = 2 }
                            }
                        }
                    ]
                },
                MetaData = new MetaData { RequestId = Guid.NewGuid().ToString(), Time = DateTime.UtcNow.ToString("o") }
            });
    }

    [Given(@"the API returns a warning for ""(.*)""")]
    public void GivenTheApiReturnsAWarningFor(string performanceId)
    {
        apiClientMock
            .Setup(c => c.RequestSnapshotAsync(It.IsAny<SnapshotRequest>(), It.IsAny<string>()))
            .ReturnsAsync(new SnapshotResponse
            {
                StatusCode = HttpStatusCode.OK,
                Data = new DataContainer(),
                MetaData = new MetaData
                {
                    RequestId = Guid.NewGuid().ToString(),
                    Time = DateTime.UtcNow.ToString("o"),
                    Messages =
                    [
                        new WarningMessage { PerformanceId = performanceId, Severity = "Warning", Code = "404", Message = "Not found" }
                    ]
                }
            });
    }

    [Given(@"the API returns an unauthorized response")]
    public void GivenTheApiReturnsAnUnauthorizedResponse()
    {
        apiClientMock
            .Setup(c => c.RequestSnapshotAsync(It.IsAny<SnapshotRequest>(), It.IsAny<string>()))
            .ReturnsAsync(new SnapshotResponse
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Data = new DataContainer(),
                MetaData = new MetaData { RequestId = Guid.NewGuid().ToString(), Time = DateTime.UtcNow.ToString("o") }
            });
    }

    [When(@"I request a snapshot")]
    public async Task WhenIRequestASnapshot()
    {
        response = await service.RequestSnapshotAsync(request);
    }

    [Then(@"I receive a 200 OK response")]
    public void ThenIReceiveA200OKResponse()
    {
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Then(@"I receive a 401 Unauthorized response")]
    public void ThenIReceiveA401UnauthorizedResponse()
    {
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Then(@"the response contains data for ""(.*)""")]
    public void ThenTheResponseContainsDataFor(string performanceId)
    {
        response.Data.Realtime.Should().Contain(d => d.PerformanceId == performanceId);
    }

    [Then(@"the response contains a warning for ""(.*)""")]
    public void ThenTheResponseContainsAWarningFor(string performanceId)
    {
        response.MetaData.Messages.Should().Contain(m => m.PerformanceId == performanceId);
    }

    [Then(@"the response contains ""(.*)"" data for ""(.*)""")]
    public void ThenTheResponseContainsEventDataFor(string eventType, string performanceId)
    {
        var instrument = response.Data.Realtime.Should().Contain(d => d.PerformanceId == performanceId).Subject;
        instrument.Events.Should().ContainKey(eventType);
    }
}