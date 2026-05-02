using FlexPointRetailApp.OrderService.Interfaces;
using FlexPointRetailApp.OrderService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlexPointRetailApp.OrderService.Controllers
{
    // Controller → orchestrates request/response, SRP
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderSerivce)
        {
            _orderService = orderSerivce;
        }

        [HttpPost]          
        public async Task<IActionResult> Create(OrderDto dto)
        {
            var order = await _orderService.CreateOrderAsync(dto);
            return Ok(order);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            return Ok(order);
        }
    }
}
