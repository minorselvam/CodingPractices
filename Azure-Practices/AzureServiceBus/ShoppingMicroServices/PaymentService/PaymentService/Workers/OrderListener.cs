// Import required namespaces
using Azure.Messaging.ServiceBus;   // Azure Service Bus SDK
using PaymentService.Models;        // Models: Order, Payment
using System.Text.Json;             // For JSON serialization/deserialization

namespace PaymentService.Workers;

// BackgroundService ensures this listener runs continuously
public class OrderListener : BackgroundService
{
    // Processor listens to incoming messages from a queue
    private readonly ServiceBusProcessor _processor;
    // Sender publishes new messages to another queue
    private readonly ServiceBusSender _sender;

    // Constructor: sets up processor and sender
    public OrderListener(ServiceBusClient client)
    {
        // Listen to messages from "orderqueue" (published by OrderService)
        _processor = client.CreateProcessor("orderqueue", new ServiceBusProcessorOptions());
        // Send messages to "paymentqueue" (to be consumed by ShippingService)
        _sender = client.CreateSender("paymentqueue");
    }

    // This method runs automatically when the service starts
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Define what happens when a message arrives in orderqueue
        _processor.ProcessMessageAsync += async args =>
        {
            // Deserialize the incoming message body into an Order object
            var order = JsonSerializer.Deserialize<Order>(args.Message.Body.ToString());

            // Create a Payment object to confirm payment for this order
            var payment = new Payment(order!.Id, "Payment Done");

            // Serialize and publish the Payment object to paymentqueue
            await _sender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(payment)));

            // Mark the original order message as processed (remove from queue)
            await args.CompleteMessageAsync(args.Message);

            // Log to console for visibility
            Console.WriteLine($"Payment processed for Order {order.Id}");
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

/*
🧩 Why Do We Need This Listener?
Role in workflow:

Consumes OrderPlaced messages from orderqueue.

Processes payment logic (here simplified to “Payment Done”).

Publishes PaymentDone messages to paymentqueue.

Azure Service Bus principle:

This listener is a subscriber to one queue and a publisher to another.

It ensures decoupling: PaymentService doesn’t need to call ShippingService directly — it just drops a message into the bus.
 */