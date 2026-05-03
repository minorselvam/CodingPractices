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

        [HttpGet("test-exception")]
        public IActionResult TestException()
        {
            throw new InvalidOperationException("This is a test exception!");
        }

        [HttpGet("test-multiple-catch-block-and-finally-block")]
        public IActionResult TestMultipleCatchBlockAndFinallyBlock()
        {
            try
            {
                // Trigger a different exception (not IndexOutOfRangeException)
                //throw new InvalidOperationException("This is a test for the general catch block!");

                int[] numbers = { 1, 2, 3 };
                var value = numbers[5]; // This will throw IndexOutOfRangeException
                return Ok(value);
            }
            catch (IndexOutOfRangeException ex)
            {
                // Specific exception handling
                return BadRequest(new
                {
                    ErrorType = "IndexOutOfRangeException",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                // General fallback exception handling
                return StatusCode(500, new
                {
                    ErrorType = "GeneralException",
                    Message = ex.Message
                });
            }
            finally
            {
                // Code here ALWAYS runs, whether an exception occurred or not
                // Useful for cleanup, logging, or releasing resources
                Console.WriteLine("Finally block executed: cleanup or logging can go here.");
            }
        }

    }
}
