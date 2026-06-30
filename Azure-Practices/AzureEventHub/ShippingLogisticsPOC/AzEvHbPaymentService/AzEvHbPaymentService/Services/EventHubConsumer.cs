using Azure.Messaging.EventHubs.Consumer;
using SharedContracts;
using System.Text.Json;

namespace AzEvHbPaymentService.Services;

public class EventHubConsumer : BackgroundService
{
    private readonly IConfiguration _config;
    private readonly EventHubProducer _producer;

    public EventHubConsumer(IConfiguration config, EventHubProducer producer)
    {
        _config = config;
        _producer = producer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventHubConsumerClient(
            EventHubConsumerClient.DefaultConsumerGroupName,
            _config["EventHub:ConnectionString"],
            _config["EventHub:Name"]);

        await foreach (var evt in consumer.ReadEventsAsync(stoppingToken))
        {
            var order = JsonSerializer.Deserialize<Order>(
                evt.Data.EventBody.ToString()
            );

            Console.WriteLine($"Processing payment for Order {order.Id}");

            var payment = new Payment(order.Id, true);
            await _producer.PublishAsync(payment);
        }
    }
}
