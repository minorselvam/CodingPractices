using OrderService.Domain.Entities;

namespace OrderService.Application.Customers.Queries
{
    public interface ICustomerQueryRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
    }
}
