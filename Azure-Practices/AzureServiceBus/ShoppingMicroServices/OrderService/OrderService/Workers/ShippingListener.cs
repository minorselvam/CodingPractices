// Import required namespaces
using Azure.Messaging.ServiceBus;   // Provides classes to interact with Azure Service Bus
using OrderService.Models;          // Imports the Shipping model
using System.Text.Json;             // Used for deserializing JSON messages

namespace OrderService.Workers;

// A background service that runs continuously in the OrderService
public class ShippingListener : BackgroundService
{
    // A processor that listens to messages from a specific queue
    private readonly ServiceBusProcessor _processor;

    // Constructor: creates a processor for the "shippingqueue"
    public ShippingListener(ServiceBusClient client)
    {
        _processor = client.CreateProcessor("shippingqueue", new ServiceBusProcessorOptions());
    }

    // This method runs when the background service starts
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Define what happens when a message is received
        _processor.ProcessMessageAsync += async args =>
        {
            // Deserialize the message body into a Shipping object
            var shipping = JsonSerializer.Deserialize<Shipping>(args.Message.Body.ToString());

            // Log the shipping status to the console
            Console.WriteLine($"Order {shipping?.OrderId} marked as shipped!");

            // Mark the message as completed so it is removed from the queue
            await args.CompleteMessageAsync(args.Message);
        };

        // Define what happens if there is an error while processing
        _processor.ProcessErrorAsync += args =>
        {
            Console.WriteLine($"Error: {args.Exception}");
            return Task.CompletedTask;
        };

        // Start listening for messages
        await _processor.StartProcessingAsync(stoppingToken);
    }
}


/*
 * 🧩 Why Do We Need This?
The OrderService doesn’t just send messages — it also needs to receive updates when shipping is completed.

The ShippingListener is a subscriber to the shippingqueue.

When the ShippingService publishes a message like:

json
{"OrderId":"1234","Status":"Shipping Done"}

this listener consumes it, deserializes it, and logs/updates the order status.

📡 Role in Azure Service Bus Communication
Azure Service Bus is a message broker. Services don’t call each other directly; they communicate via queues/topics.

ShippingListener is the consumer side of the publish/subscribe pattern:

Publisher: ShippingService → sends ShippingDone message to shippingqueue.

Subscriber: OrderService → listens with ShippingListener, processes the message.

This ensures loose coupling:

OrderService doesn’t need to know where ShippingService runs.

Messages are durable — if OrderService is down, it will still receive the shipping update later.

🚀 Summary
ShippingListener is a background worker that continuously listens for messages from the shippingqueue.

It deserializes those messages into Shipping objects and updates/logs the order status.

Its role is to close the loop in the workflow: Order → Payment → Shipping → back to Order.

Without it, the OrderService would never know when an order has been shipped.
*/


/*
 A background service that runs continuously in the OrderService. which means it is running always in the app.  
 How it is running continously without any start or trigger event? Is it running because of BackgroundService. 
 Explain it working principle.

 The ShippingListener (and any class inheriting from BackgroundService) runs continuously without you explicitly starting it.

⚙️ The Role of BackgroundService
In .NET, BackgroundService is an abstract base class for implementing long-running tasks.

When you register it in Program.cs with:

csharp
builder.Services.AddHostedService<ShippingListener>();

you’re telling the ASP.NET Core host:
“This service should start automatically when the application starts, and keep running until the app shuts down.”

🔄 Working Principle
Application Host Lifecycle

ASP.NET Core apps run inside a generic host (IHost).

The host manages the lifecycle of services: starting, stopping, disposing.

Hosted Services

Any class implementing IHostedService (which BackgroundService does) is automatically started by the host.

On startup, the host calls StartAsync() → which internally calls your overridden ExecuteAsync().

Continuous Execution

ExecuteAsync(CancellationToken stoppingToken) runs in the background.

In the case of ShippingListener, it starts the Service Bus processor (StartProcessingAsync) which itself listens continuously for new messages.

No manual trigger is needed — the processor keeps polling Service Bus and invokes your handler whenever a message arrives.

Graceful Shutdown

When the app stops, the host signals the CancellationToken (stoppingToken).

Your background service can stop processing and clean up resources.

📡 Why This Matters for Azure Service Bus
Publish/Subscribe model:

Services publish messages to queues/topics.

Listeners (like ShippingListener) subscribe and process them.

The listener must be always running so it can react immediately when a message arrives.

By using BackgroundService, you ensure the listener is active for the entire lifetime of the microservice, without needing manual triggers.

🧩 Analogy
Think of BackgroundService as a security guard:

You hire them (register in DI).

When the building opens (app starts), they automatically begin their shift.

They keep watching continuously (listening for messages).

When the building closes (app stops), they go home (shutdown gracefully).

So yes — the continuous running is because of BackgroundService. 
It integrates with the ASP.NET Core host lifecycle, ensuring your message listener is always active as long as the app is alive.
*/