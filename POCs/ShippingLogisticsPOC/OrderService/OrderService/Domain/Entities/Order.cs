namespace OrderService.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // ✅ Business rules live here, independent of EF Core/Dapper
        public bool IsValid() => TotalAmount > 0;

        // Example rule: Orders above ₹50,000 require manager approval
        public bool RequiresApproval() => TotalAmount > 50000;
    }
}
