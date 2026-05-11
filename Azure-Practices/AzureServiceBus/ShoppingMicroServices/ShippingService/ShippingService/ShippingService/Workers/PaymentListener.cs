// Import required namespaces
using Azure.Messaging.ServiceBus;   // Azure Service Bus SDK
using ShippingService.Models;       // Models: Payment, Shipping
using System.Text.Json;             // For JSON serialization/deserialization

namespace ShippingService.Workers;

// BackgroundService ensures this listener runs continuously
public class PaymentListener : BackgroundService
{
    // Processor listens to incoming messages from a queue
    private readonly ServiceBusProcessor _processor;
    // Sender publishes new messages to another queue
    private readonly ServiceBusSender _sender;

    // Constructor: sets up processor and sender
    public PaymentListener(ServiceBusClient client)
    {
        // Listen to messages from "paymentqueue" (published by PaymentService)
        _processor = client.CreateProcessor("paymentqueue", new ServiceBusProcessorOptions());
        // Send messages to "shippingqueue" (to be consumed by OrderService)
        _sender = client.CreateSender("shippingqueue");
    }

    // This method runs automatically when the service starts
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Define what happens when a message arrives in paymentqueue
        _processor.ProcessMessageAsync += async args =>
        {
            // Deserialize the incoming message body into a Payment object
            var payment = JsonSerializer.Deserialize<Payment>(args.Message.Body.ToString());

            // Create a Shipping object to confirm shipping for this order
            var shipping = new Shipping(payment!.OrderId, "Shipping Done");

            // Serialize and publish the Shipping object to shippingqueue
            await _sender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(shipping)));

            // Mark the original payment message as processed (remove from queue)
            await args.CompleteMessageAsync(args.Message);

            // Log to console for visibility
            Console.WriteLine($"Shipping processed for Order {payment.OrderId}");
        };

        // Define error handling logic
        _processor.ProcessErrorAsync += args =>
        {
            Console.WriteLine($"Error: {args.Exception}");
            return Task.CompletedTask;
        };

        // Start listening for messages continuously
        await _processor.StartProcessingAsync(stoppingToken);
    }
}
