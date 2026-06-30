using Microsoft.AspNetCore.Mvc;
using SharedContracts;

namespace AzEvHbPaymentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpGet("{orderId}")]
    public IActionResult GetPaymentStatus(Guid orderId)
    {
        // For demo purposes, just return a dummy status
        return Ok(new Payment(orderId, true));
    }
}
