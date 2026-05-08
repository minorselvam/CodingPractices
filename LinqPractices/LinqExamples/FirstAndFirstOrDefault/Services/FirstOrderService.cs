using FirstAndFirstOrDefault.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFirstOrDefault.Services
{
    public class FirstOrderService
    {
        private readonly AppDbContext _context;

        public FirstOrderService(AppDbContext context)
        {
            _context = context;
        }

        public void GetFirstOrderAboveAmount(decimal amount)
        {
            try
            {
                var order = _context.Orders.First(o => o.Amount > amount);
                Console.WriteLine($"[First()] Found order: {order.CustomerName}, Amount: {order.Amount}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[First()] No order found above {amount}. Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[First()] Unexpected error: {ex.Message}");
            }
        }
    }
}
