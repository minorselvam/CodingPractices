using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CustomMiddlewareExample.CustomMiddleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        
        // Middleware constructor takes a RequestDelegate parameter
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // The InvokeAsync method is called on every HTTP request
        public async Task InvokeAsync(HttpContext context)
        {
            // Code to execute before calling the next middleware
            Console.WriteLine($"Request URL: {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);

            // Code to execute after the next middleware
            Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
        }
    }
}
