using KeyedDepncyInjcnPatn.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeyedDepncyInjcnPatn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentServices _paymentServices;
        
        public PaymentController(PaymentServices paymentServices)
        {
            _paymentServices = paymentServices; // Inject PaymentServices via DI
        }

        //The controller exposes an API endpoint /api/payment/process. The client sends PaymentType (CreditCard or PayPal) and Amount.
        //The controller passes this to the service layer.
        [HttpPost]
        [Route("process")]
        public IActionResult ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            // Delegate to PaymentServices to resolve correct processor
            _paymentServices.Execute(paymentRequest.PaymentType, paymentRequest.Amount);
            return Ok($"Payment processed for the amount {paymentRequest.Amount} for the payment type {paymentRequest.PaymentType}");
        }

    }
}
