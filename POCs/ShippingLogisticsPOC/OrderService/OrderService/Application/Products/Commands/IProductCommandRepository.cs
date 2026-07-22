using OrderService.Domain.Entities;

namespace OrderService.Application.Products.Commands
{
    public interface IProductCommandRepository
    {
        Task<Product> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
