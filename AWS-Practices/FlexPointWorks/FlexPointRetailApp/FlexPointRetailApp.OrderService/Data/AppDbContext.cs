using Microsoft.EntityFrameworkCore;
using FlexPointRetailApp.OrderService.Models;

namespace FlexPointRetailApp.OrderService.Data
{
    // DbContext → Repository Pattern foundation
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
    }
}
