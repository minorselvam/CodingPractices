namespace OrderService.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty; // max 6 digits
        public string Phone { get; set; } = string.Empty;   // max 12 digits

        //// ✅ Business rule: ensure valid ZipCode and Phone length
        //public bool IsValid() =>
        //    ZipCode.Length == 6 && Phone.Length <= 12;
    }
}
