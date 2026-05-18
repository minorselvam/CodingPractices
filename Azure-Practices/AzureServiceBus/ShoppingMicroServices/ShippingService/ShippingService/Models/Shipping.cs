namespace ShippingService.Models
{
    // Represents a shipping status message to be sent back to OrderService
    public record Shipping(Guid OrderId, string Status);
}
