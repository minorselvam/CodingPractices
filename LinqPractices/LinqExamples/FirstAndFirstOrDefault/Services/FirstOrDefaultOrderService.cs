using FirstAndFirstOrDefault.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFirstOrDefault.Services
{
    public class FirstOrDefaultOrderService
    {
        private readonly AppDbContext _context;

        public FirstOrDefaultOrderService(AppDbContext context)
        {
            _context = context;
        }

        public void GetFirstOrDefaultOrderAboveAmount(decimal amount)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.Amount > amount);
                if (order != null)
                {
                    Console.WriteLine($"[FirstOrDefault()] Found order: {order.CustomerName}, Amount: {order.Amount}");
                }
                else
                {
                    Console.WriteLine($"[FirstOrDefault()] No order found above {amount}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FirstOrDefault()] Unexpected error: {ex.Message}");
            }
        }
    }
}
