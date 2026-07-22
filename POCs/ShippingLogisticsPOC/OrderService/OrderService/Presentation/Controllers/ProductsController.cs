using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Products.Commands;
using OrderService.Application.Products.Queries;
using OrderService.Domain.Entities;

namespace OrderService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductCommandRepository _commandRepo;
        private readonly IProductQueryRepository _queryRepo;

        public ProductsController(IProductCommandRepository commandRepo, IProductQueryRepository queryRepo)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
        }

        // ✅ Query side (Dapper)
        [HttpGet("GetAllProducts")]   // React: GET /api/Products/GetAllProducts
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _queryRepo.GetAllProductAsync());
        }

        [HttpGet("GetProduct/{id}")]  // React: GET /api/Products/GetProduct/5
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _queryRepo.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("SearchProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts(string name)
        {
            var products = await _queryRepo.SearchProductsByNameAsync(name);
            return Ok(products);
        }


        // ✅ Command side (EF Core)
        [HttpPost("CreateProduct")]   // React: POST /api/Products/CreateProduct
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var created = await _commandRepo.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = created.ProductId }, created);
        }

        [HttpPut("UpdateProduct/{id}")]   // React: PUT /api/Products/UpdateProduct/5
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId) return BadRequest();
            await _commandRepo.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id}")] // React: DELETE /api/Products/DeleteProduct/5
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _commandRepo.DeleteProductAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
