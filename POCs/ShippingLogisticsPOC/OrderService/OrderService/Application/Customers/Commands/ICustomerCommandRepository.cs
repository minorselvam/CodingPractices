using OrderService.Domain.Entities;

namespace OrderService.Application.Customers.Commands
{
    public interface ICustomerCommandRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
