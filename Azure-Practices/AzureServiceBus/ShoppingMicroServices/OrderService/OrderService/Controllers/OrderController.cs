// Import required namespaces
using Azure.Messaging.ServiceBus;   // Provides classes to interact with Azure Service Bus
using Microsoft.AspNetCore.Mvc;     // Provides ASP.NET Core MVC features like controllers and routing
using OrderService.Models;          // Imports the Order model defined in the project
using System.Text.Json;             // Used for serializing objects into JSON

namespace OrderService.Controllers;

// Marks this class as an API controller
[ApiController]
// Defines the base route for this controller: api/order
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    // A ServiceBusSender is used to send messages to a specific queue
    private readonly ServiceBusSender _sender;

    // Constructor: receives a ServiceBusClient (registered in Program.cs)
    // and creates a sender for the "orderqueue"
    public OrderController(ServiceBusClient client)
    {
        _sender = client.CreateSender("orderqueue");
    }

    public OrderController( )
    {
         
    }

    // Defines an HTTP POST endpoint at: api/order/place
    [HttpPost("place")]
    public async Task<IActionResult> PlaceOrder([FromBody] Order order)
    {
        // Serialize the Order object into JSON and wrap it in a ServiceBusMessage
        var message = new ServiceBusMessage(JsonSerializer.Serialize(order));

        // Send the message to Azure Service Bus (to the "orderqueue")
        await _sender.SendMessageAsync(message);

        // Return a 200 OK response with a confirmation message
        return Ok($"Order placed with Id {order.Id}");
    }

    [HttpGet("TestOrder")]
    public string TestOrder()
    {
        return  "test order result";
    }
}

/*
 var message = new ServiceBusMessage(JsonSerializer.Serialize(order));

Question - what value the message will be have?

Suppose you send this JSON body to the OrderController:
{
  "id": "d3f1a8b2-9c4e-4b7a-8f2a-123456789abc",
  "product": "Laptop"
}

That gets bound to an Order object:
var order = new Order(
    Guid.Parse("d3f1a8b2-9c4e-4b7a-8f2a-123456789abc"),
    "Laptop"
);


JsonSerializer.Serialize(order) converts the object into a JSON string:
{"Id":"d3f1a8b2-9c4e-4b7a-8f2a-123456789abc","Product":"Laptop"}


ServiceBusMessage Content
The ServiceBusMessage wraps that JSON string as its Body. Conceptually, the message looks like this:

Body:
{"Id":"d3f1a8b2-9c4e-4b7a-8f2a-123456789abc","Product":"Laptop"}

MessageId: (auto-generated unless you set it)

ContentType: "application/json"

Other metadata: Delivery count, enqueue time, etc. (managed by Azure Service Bus)

So the message object is essentially a JSON payload + metadata ready to be sent to the orderqueue.

🧩 Why This Matters
The Body is what downstream services (Payment, Shipping) will deserialize back into their model classes.

The metadata (like MessageId, CorrelationId) can be used for tracking, retries, or correlation across services.

👉 In short: for the example above, the message body is exactly:
{"Id":"d3f1a8b2-9c4e-4b7a-8f2a-123456789abc","Product":"Laptop"}



*/
