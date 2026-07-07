using FlexPointRetailApp.OrderService.Models;
namespace FlexPointRetailApp.OrderService.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderDto order);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
