namespace OrderService.Models
{
    public record Shipping(Guid OrderId, string Status);
}
