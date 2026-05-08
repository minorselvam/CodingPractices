using FirstAndFirstOrDefault.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFirstOrDefault.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // In-memory database for demo purposes
            optionsBuilder.UseInMemoryDatabase("OrdersDb");
        }
    }
}
