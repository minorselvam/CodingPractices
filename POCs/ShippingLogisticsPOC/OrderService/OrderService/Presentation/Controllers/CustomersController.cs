using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Customers.Commands;
using OrderService.Application.Customers.Queries;
using OrderService.Domain.Entities;

namespace OrderService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerCommandRepository _commandRepo;
        private readonly ICustomerQueryRepository _queryRepo;

        // ✅ Dependency Injection: Controller depends only on abstractions
        public CustomersController(ICustomerCommandRepository commandRepo, ICustomerQueryRepository queryRepo)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
        }

        // ✅ Query side (Dapper)
        [HttpGet("GetAllCustomers")]   // React: GET /api/Customers/GetAllCustomers
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(await _queryRepo.GetAllCustomerAsync());
        }

        [HttpGet("GetCustomer/{id}")]  // React: GET /api/Customers/GetCustomer/5
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _queryRepo.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // ✅ Command side (EF Core)
        [HttpPost("CreateCustomer")]   // React: POST /api/Customers/CreateCustomer
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            //if (!customer.IsValid()) return BadRequest("Invalid customer data");
            var created = await _commandRepo.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = created.CustomerId }, created);
        }

        [HttpPut("UpdateCustomer/{id}")]   // React: PUT /api/Customers/UpdateCustomer/5
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId) return BadRequest();
            await _commandRepo.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpDelete("DeleteCustomer/{id}")] // React: DELETE /api/Customers/DeleteCustomer/5
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleted = await _commandRepo.DeleteCustomerAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
