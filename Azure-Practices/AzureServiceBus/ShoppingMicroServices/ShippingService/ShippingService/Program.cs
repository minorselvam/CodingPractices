using Azure.Messaging.ServiceBus;
using ShippingService.Workers;

namespace ShippingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Register Service Bus client using connection string from appsettings.json
            builder.Services.AddSingleton(new ServiceBusClient(
                builder.Configuration["AzureServiceBus"]));

            // Register background worker (PaymentListener)
            builder.Services.AddHostedService<PaymentListener>();

            // Add controllers (optional, for health checks or monitoring)
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
