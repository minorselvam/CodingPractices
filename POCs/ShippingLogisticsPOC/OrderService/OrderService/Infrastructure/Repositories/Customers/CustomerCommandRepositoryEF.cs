using Microsoft.EntityFrameworkCore;
using OrderService.Application.Customers.Commands;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories.Customers
{
    // ✅ EF Core implementation for Customer commands (writes)
    // Benefits: change tracking, migrations, transactions
    public class CustomerCommandRepositoryEF : ICustomerCommandRepository
    {
        private readonly OrderContext _context;

        public CustomerCommandRepositoryEF(OrderContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
