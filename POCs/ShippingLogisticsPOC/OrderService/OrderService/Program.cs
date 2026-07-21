
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Customers.Commands;
using OrderService.Application.Customers.Queries;
using OrderService.Application.Orders.Commands;
using OrderService.Application.Orders.Queries;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories.Customers;
using OrderService.Infrastructure.Repositories.Orders;
using System.Data;

namespace OrderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ✅ EF Core for Commands (writes)
            builder.Services.AddDbContext<OrderContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // ✅ Dapper for Queries (reads)
            builder.Services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IOrderQueryRepository, OrderQueryRepositoryDapper>();

            // ✅ Register EF Core command repository (writes)
            builder.Services.AddScoped<IOrderCommandRepository, OrderCommandRepositoryEF>();

            // ✅ Register Dapper query repository (reads)
            builder.Services.AddScoped<IOrderQueryRepository, OrderQueryRepositoryDapper>();


            // ✅ Register Customer repositories
            builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepositoryEF>();
            builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepositoryDapper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
