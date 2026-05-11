namespace ShippingService.Models
{
    // Represents a payment confirmation message received from PaymentService
    public record Payment(Guid OrderId, string Status);
}
