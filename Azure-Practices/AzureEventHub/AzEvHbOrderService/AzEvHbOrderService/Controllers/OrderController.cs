using Microsoft.AspNetCore.Mvc;
using SharedContracts;
using AzEvHbOrderService.Services;

namespace AzEvHbOrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly EventHubProducer _producer;

    public OrderController(EventHubProducer producer) => _producer = producer;

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        await _producer.PublishAsync(order);
        return Ok($"Order {order.Id} published");
    }
}
