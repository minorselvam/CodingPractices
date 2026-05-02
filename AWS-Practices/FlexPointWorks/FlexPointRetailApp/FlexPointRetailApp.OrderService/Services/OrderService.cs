using FlexPointRetailApp.OrderService.Interfaces;
using FlexPointRetailApp.OrderService.Models;

namespace FlexPointRetailApp.OrderService.Services
{
    // Service Layer → Business logic, SRP
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        // Dependency Injection → DIP (Dependency Inversion Principle)
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync(OrderDto dto)
        {
            var order = new Order
            {
                CustomerName = dto.CustomerName,
                Amount = dto.Amount,
                CreatedDate = DateTime.UtcNow,
                Status = "Created"
            };
            return await _orderRepository.AddOrderAsync(order);
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsyncById(orderId);
            return order;
        }
    }
}
