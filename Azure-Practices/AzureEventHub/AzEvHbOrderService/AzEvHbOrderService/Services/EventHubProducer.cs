using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Text.Json;

namespace AzEvHbOrderService.Services;

public class EventHubProducer
{
    private readonly EventHubProducerClient _client;

    public EventHubProducer(IConfiguration config)
    {
        _client = new EventHubProducerClient(
            config["EventHub:ConnectionString"],
            config["EventHub:Name"]);
    }

    public async Task PublishAsync<T>(T message)
    {
        using EventDataBatch batch = await _client.CreateBatchAsync();
        batch.TryAdd(new Azure.Messaging.EventHubs.EventData(
            JsonSerializer.SerializeToUtf8Bytes(message)
        ));
        await _client.SendAsync(batch);
    }
}
