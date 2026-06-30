using Microsoft.AspNetCore.Mvc;
using SharedContracts;

namespace AzEvHbShippingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShippingController : ControllerBase
{
    [HttpGet("{orderId}")]
    public IActionResult GetShippingStatus(Guid orderId)
    {
        // For demo purposes, just return a dummy status
        return Ok($"Shipping started for Order {orderId}");
    }
}
