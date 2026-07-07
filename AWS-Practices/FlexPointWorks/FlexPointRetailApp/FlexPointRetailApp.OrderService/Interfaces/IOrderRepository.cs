using FlexPointRetailApp.OrderService.Models;

namespace FlexPointRetailApp.OrderService.Interfaces
{
    // Interface Segregation Principle → small, focused interface
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<Order?> GetOrderAsyncById(int id);
        Task<IEnumerable<Order>> GetAllOrders();
    }
}
