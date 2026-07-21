using OrderService.Domain.Entities;

namespace OrderService.Application.Orders.Commands
{
    // ✅ Command side: write operations - Using EF Core
    public interface IOrderCommandRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
    }
}
