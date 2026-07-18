using Microsoft.EntityFrameworkCore;
using OrderService.Application.Commands;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories
{
    // ✅ EF Core implementation for commands (writes)
    // Benefits: change tracking, migrations, transactions
    public class OrderCommandRepositoryEF :  IOrderCommandRepository
    {
        private readonly OrderContext _context;

        public OrderCommandRepositoryEF(OrderContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if(order==null) { return false; }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
