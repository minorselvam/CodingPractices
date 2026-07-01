namespace Products.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Type { get; set; } = string.Empty;       // TV, Mobile, WashingMachine
        public string Brand { get; set; } = string.Empty;      // LG, Samsung, Bosch
        public string ProductName { get; set; } = string.Empty; // e.g., Samsung Ultra 2026 New
        public decimal Price { get; set; }
    }
}
