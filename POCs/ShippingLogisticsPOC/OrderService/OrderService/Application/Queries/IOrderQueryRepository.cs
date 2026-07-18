using OrderService.Domain.Entities;

namespace OrderService.Application.Queries
{
    // ✅ Query side: read operations - CQRS Pattern
    public interface IOrderQueryRepository
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
    }
}
