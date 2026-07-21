using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Orders.Commands;
using OrderService.Application.Orders.Queries;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Data;

namespace OrderService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;
        private readonly IOrderCommandRepository _commandRepo;
        private readonly IOrderQueryRepository _queryRepo;

        // ✅ Dependency Injection: Controller depends only on abstractions
        public OrdersController(IOrderCommandRepository commandRepo, IOrderQueryRepository queryRepo)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
        }

        // ✅ Query side (Dapper)
        [HttpGet("GetAllOrders")] //api/Orders/GetAllOrders
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _queryRepo.GetAllOrderAsync());
        }

        [HttpGet("GetOrder/{id}")] ///api/Orders/GetOrder/5
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _queryRepo.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        // ✅ Command side (EF Core)
        [HttpPost("CreateOrder")]  ///api/Orders/CreateOrder
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            if (!order.IsValid()) return BadRequest("Invalid order");

            if (order.RequiresApproval())
                return BadRequest("Order requires manager approval");

            var created = await _commandRepo.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = created.OrderId }, created);
        }

        [HttpPut("UpdateOrder/{id}")] ///api/Orders/UpdateOrder/5
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.OrderId) return BadRequest();
            await _commandRepo.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("DeleteOrder/{id}")] ///api/Orders/DeleteOrder/5
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deleted = await _commandRepo.DeleteOrderAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

    }
}
