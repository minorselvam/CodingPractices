using FlexPointRetailApp.OrderService.Data;
using FlexPointRetailApp.OrderService.Interfaces;
using FlexPointRetailApp.OrderService.Models;
using Microsoft.EntityFrameworkCore;

namespace FlexPointRetailApp.OrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> GetOrderAsyncById(int orderId)
        {
           return await _dbContext.Orders.FindAsync(orderId);
        }
    }
}
