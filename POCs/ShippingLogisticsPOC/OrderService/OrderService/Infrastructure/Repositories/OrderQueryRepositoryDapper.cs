using System.Data;
using Dapper;
using OrderService.Application.Queries;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Repositories
{
    // ✅ Dapper implementation for queries (reads)
    // Benefits: faster reads, lightweight mapping, full SQL control
    public class OrderQueryRepositoryDapper : IOrderQueryRepository
    {
        private readonly IDbConnection _connection;
        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            var sql = "SELECT * FROM Orders";
            return await _connection.QueryAsync<Order>(sql);
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            var sql = "SELECT * FROM Orders WHERE OrderId = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Order>(sql, new { Id = id });
        }
    }
}
