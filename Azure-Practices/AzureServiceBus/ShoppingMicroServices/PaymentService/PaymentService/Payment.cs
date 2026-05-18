namespace PaymentService.Models
{
    public record Payment(Guid OrderId, string Status);
}
