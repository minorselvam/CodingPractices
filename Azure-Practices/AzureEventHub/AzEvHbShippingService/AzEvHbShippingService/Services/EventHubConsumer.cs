using Azure.Messaging.EventHubs.Consumer;
using SharedContracts;
using System.Text.Json;

namespace AzEvHbShippingService.Services;

public class EventHubConsumer : BackgroundService
{
    private readonly IConfiguration _config;

    public EventHubConsumer(IConfiguration config) => _config = config;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventHubConsumerClient(
            EventHubConsumerClient.DefaultConsumerGroupName,
            _config["EventHub:ConnectionString"],
            _config["EventHub:Name"]);

        await foreach (var evt in consumer.ReadEventsAsync(stoppingToken))
        {
            var payment = JsonSerializer.Deserialize<Payment>(
                evt.Data.EventBody.ToString()
            );

            if (payment?.Success == true)
            {
                Console.WriteLine($"Shipping started for Order {payment.OrderId}");
            }
        }
    }
}
