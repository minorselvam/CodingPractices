
using CustomMiddlewareExample.CustomMiddleware;
using Microsoft.OpenApi.Models;

namespace CustomMiddlewareExample
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

            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Add custom header parameters for username and password
                c.OperationFilter<AddRequiredHeadersOperationFilter>();
            });
            /*
                To pass the username and password to test your custom middleware authentication through Swagger in ASP.NET Core, 
                you can simulate this by sending the credentials as custom headers in the Swagger UI request. 
                Since your middleware checks for username and password in the request headers, you need to configure Swagger UI 
                to allow adding these headers to requests.

                Here is how you can do that:

                1. Modify Swagger configuration to add header input for username and password
                In your Program.cs (or Startup.cs), configure Swagger to add two custom header parameters (username and password) 
                so you can input them in Swagger UI:
            */

            var app = builder.Build();

            // Add the custom middleware to the pipeline
            // Register middlewares in the required order to the pipeline
            app.UseMiddleware<Middleware1>(); // Logging
            app.UseMiddleware<Middleware2>(); // Authentication check
            app.UseMiddleware<Middleware3>(); // Terminal response
            /*
             Key Points
                Order matters: Middlewares are run in the exact order you add them.

                Terminal middleware: The last one stops the pipeline from progressing further by not calling await _next(context).

                Error handling & authentication: Authentication is checked in Middleware2; failed authentication 
                short-circuits the process.
            */

            //app.UseMiddleware<CustomMiddlewareExample.CustomMiddleware.CustomMiddleware>();

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
