using FirstAndFirstOrDefault.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFirstOrDefault.Services
{
    public class SingleOrderService
    {
        private readonly AppDbContext _context;

        public SingleOrderService(AppDbContext context)
        {
            _context = context;
        }

        public void GetSingleOrderAboveAmount(decimal amount)
        {
            try
            {
                var order = _context.Orders.Single(o => o.Amount > amount);
                Console.WriteLine($"[Single()] Found order: {order.CustomerName}, Amount: {order.Amount}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[Single()] Error: Either no order or multiple orders found above {amount}. Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Single()] Unexpected error: {ex.Message}");
            }
        }
    }
}
