using System.Data;
using Dapper;
using OrderService.Application.Customers.Queries;
using OrderService.Domain.Entities;
 
namespace OrderService.Infrastructure.Repositories.Customers
{
    // ✅ Dapper implementation for Customer queries (reads)
    // Benefits: faster reads, lightweight mapping, full SQL control
    public class CustomerQueryRepositoryDapper : ICustomerQueryRepository
    {
        private readonly IDbConnection _connection;

        // ✅ Constructor injection: DI will provide SqlConnection here
        public CustomerQueryRepositoryDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            var sql = "SELECT * FROM Customers";
            return await _connection.QueryAsync<Customer>(sql);
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            var sql = "SELECT * FROM Customers WHERE CustomerId = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });
        }
    }
}
