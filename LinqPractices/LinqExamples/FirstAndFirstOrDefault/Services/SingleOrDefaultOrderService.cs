using FirstAndFirstOrDefault.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFirstOrDefault.Services
{
    public class SingleOrDefaultOrderService
    {
        private readonly AppDbContext _context;

        public SingleOrDefaultOrderService(AppDbContext context)
        {
            _context = context;
        }

        public void GetSingleOrDefaultOrderAboveAmount(decimal amount)
        {
            try
            {
                var order = _context.Orders.SingleOrDefault(o => o.Amount > amount);
                if (order != null)
                {
                    Console.WriteLine($"[SingleOrDefault()] Found order: {order.CustomerName}, Amount: {order.Amount}");
                }
                else
                {
                    Console.WriteLine($"[SingleOrDefault()] No order found above {amount}.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[SingleOrDefault()] Error: Multiple orders found above {amount}. Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SingleOrDefault()] Unexpected error: {ex.Message}");
            }
        }
    }
}
