using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPlacementSystem
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }

        public Order(int orderId, string? productName, int quantity)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
