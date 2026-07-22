using OrderService.Domain.Entities;

namespace OrderService.Application.Products.Queries
{
    public interface IProductQueryRepository
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> SearchProductsByNameAsync(string name); // ✅ new
    }
}
