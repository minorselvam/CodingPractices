using Amazon.CloudWatchLogs;
using FlexPointRetailApp.OrderService.Data;
using FlexPointRetailApp.OrderService.Interfaces;
using FlexPointRetailApp.OrderService.Repositories;
using FlexPointRetailApp.OrderService.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.AwsCloudWatch;

namespace FlexPointRetailApp.OrderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/orderservice-.log", rollingInterval: RollingInterval.Day)
                // Future use: AWS CloudWatch sink (commented until deployment)
                // .WriteTo.AmazonCloudWatch(
                //     logGroup: "/flexpoint/orderservice",
                //     logStreamNameProvider: new DefaultLogStreamNameProvider(),
                //     cloudWatchClient: new AmazonCloudWatchLogsClient(Amazon.RegionEndpoint.APSouth2)
                // )
                .CreateLogger();

            Log.Information("Starting OrderService API...");
            var builder = WebApplication.CreateBuilder(args);

            // Hook Serilog into ASP.NET Core logging
            builder.Host.UseSerilog();

            // Configure EF Core with AWS RDS connection string
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register DI → DIP principle
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, Services.OrderService>();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //Global Exception Handling Middleware
            /*
                Why It’s Needed (recap in plain words)
                Without this middleware, unhandled exceptions return ugly HTML error pages.
                This centralizes error handling → no need for try/catch in every controller.
                Ensures consistent JSON error responses across your API.
                Helps with logging and debugging (Serilog now logs to console, file, and later CloudWatch).
            */

            // app.UseExceptionHandler(...)
            // Registers a middleware that intercepts unhandled exceptions in the request pipeline.
            // Instead of crashing or returning a generic HTML error, it lets you define a custom response.
            app.UseExceptionHandler(errorApp =>
                {
                    // errorApp.Run(...)
                    // Defines what happens when an exception occurs.
                    // Here, we set the HTTP response manually.
                    errorApp.Run(async context =>
                        {
                            // context.Response.ContentType = "application/json"
                            // Ensures the error response is JSON (not HTML).
                            // Useful for APIs, since clients expect structured data.
                            context.Response.ContentType = "application/json";

                            // var exception = ...
                            // Retrieves the actual exception object that was thrown.
                            // This gives you access to Message, InnerException, stack trace, etc.
                            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                            // Log to Serilog (Console, File, and later CloudWatch)
                            Log.Error(exception, "Unhandled exception occurred");

                            // WriteAsJsonAsync(...)
                            // Serializes the error details into JSON and writes them to the response.
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = exception?.Message,
                                Inner = exception?.InnerException?.Message
                            });
                        }
                    );
                }
            );

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
