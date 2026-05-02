namespace FlexPointRetailApp.OrderService.Models
{
    // DTO → immutable record, modern .NET 8 feature
    public record OrderDto(string CustomerName, decimal Amount);
}
