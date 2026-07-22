using System.Data;
using Dapper;
using OrderService.Application.Products.Queries;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Repositories.Products
{
    public class ProductQueryRepositoryDapper : IProductQueryRepository
    {
        private readonly IDbConnection _connection;

        public ProductQueryRepositoryDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            var sql = "SELECT * FROM Products";
            return await _connection.QueryAsync<Product>(sql);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE ProductId = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Product>> SearchProductsByNameAsync(string name)
        {
            var sql = "SELECT * FROM Products WHERE ProductName LIKE @Search";
            return await _connection.QueryAsync<Product>(sql, new { Search = "%" + name + "%" });
        }
    }
}
