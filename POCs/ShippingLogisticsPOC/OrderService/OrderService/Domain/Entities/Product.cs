namespace OrderService.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Type { get; set; } = string.Empty;       // e.g., TV, Mobile
        public string Brand { get; set; } = string.Empty;      // e.g., LG, Samsung
        public string ProductName { get; set; } = string.Empty; // e.g., Samsung Ultra 2026
        public decimal Price { get; set; }
    }
}
