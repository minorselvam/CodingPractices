
using KeyedDepncyInjcnPatn.Interfaces;
using KeyedDepncyInjcnPatn.Processors;
using KeyedDepncyInjcnPatn.Services;

namespace KeyedDepncyInjcnPatn
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

            // Register keyed services (Creational pattern via DI)
            //This is where you configure DI. Each processor is registered with a key (CreditCard, PayPal).
            //The DI container now knows how to resolve them dynamically.
            builder.Services.AddKeyedTransient<IReportGenerator>("CreditCard", (sp, key) => new CreditCardProcessor());
            builder.Services.AddKeyedTransient<IReportGenerator>("PayPal", (sp,key) => new PaypalProcessor());

            // Register PaymentServices (business logic layer)
            builder.Services.AddTransient<PaymentServices>();

;           var app = builder.Build();

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

/*
    🏭 What It Is
        Keyed Dependency Injection (DI) is a creational design pattern supported natively in .NET 8.
        It allows you to register multiple implementations of the same interface with unique keys (like "CreditCard" or "PayPal").
        At runtime, you can resolve the correct implementation by passing the key, instead of writing factories or filtering manually.

    ⚠️ Problem It Solves
        Before .NET 8, if you registered multiple implementations of an interface, DI would only inject the last registered one.
        To use different implementations, you had to:
            Inject IEnumerable<T> and filter manually, or
            Write a factory class to decide which implementation to return.
            This added boilerplate and complexity.

    ✅ Why It Was Introduced
        To simplify object creation when multiple implementations exist.
        To make client code cleaner and more declarative.
        To align with other DI containers (like Autofac) that already supported named/keyed services.
        To reduce reliance on custom factories in enterprise apps. 
*/

/*

🎯 Easy Memory Flow
    Interface → defines contract (IReportGenerator).
    Processors → implement contract (CreditCardProcessor, PaypalProcessor).
    Registration of Service→ register each processor with a key in Program.cs.
    Service Layer → PaymentServices resolves correct processor dynamically.
    Controller → exposes API endpoint to accept client input.
    Client → passes PaymentType dynamically (CreditCard or PayPal).

👉 Think of it as I → P → R → S → C → Client.

*/
