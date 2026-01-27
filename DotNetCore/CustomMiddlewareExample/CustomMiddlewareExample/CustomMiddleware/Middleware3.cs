namespace CustomMiddlewareExample.CustomMiddleware
{
    public class Middleware3
    {
        private readonly RequestDelegate _next;

        public Middleware3(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Middleware3: Generating response.");
            await context.Response.WriteAsync("Hello from Middleware3 - End of pipeline!");
        }
    }
}
