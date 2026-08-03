
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OrderService.Application.Customers.Commands;
using OrderService.Application.Customers.Queries;
using OrderService.Application.Orders.Commands;
using OrderService.Application.Orders.Queries;
using OrderService.Application.Products.Commands;
using OrderService.Application.Products.Queries;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories.Customers;
using OrderService.Infrastructure.Repositories.Orders;
using OrderService.Infrastructure.Repositories.Products;
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
            builder.Services.AddDbContext<OrderContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LogisticsPOC")));
            // ✅ Dapper for Queries (reads)
            builder.Services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(builder.Configuration.GetConnectionString("LogisticsPOC")));
            builder.Services.AddScoped<IOrderQueryRepository, OrderQueryRepositoryDapper>();

            // ✅ Register EF Core command repository (writes)
            builder.Services.AddScoped<IOrderCommandRepository, OrderCommandRepositoryEF>();

            // ✅ Register Dapper query repository (reads)
            builder.Services.AddScoped<IOrderQueryRepository, OrderQueryRepositoryDapper>();


            // ✅ Register Customer repositories
            builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepositoryEF>();
            builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepositoryDapper>();

            // ✅ Register Products repositories
            builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepositoryEF>();
            builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepositoryDapper>();

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins(
                            "http://localhost:4200",                // ✅ Angular dev server
                            "https://your-frontend.azurewebsites.net" // ✅ Angular app in Azure
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            // Register health checks
            builder.Services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());

            var app = builder.Build();

            // Map health check endpoints
            app.MapHealthChecks("/health/live");
            app.MapHealthChecks("/health/ready");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Enable CORS
            app.UseCors("AllowFrontend");

            app.MapControllers();

            app.Run();
        }
    }
}
