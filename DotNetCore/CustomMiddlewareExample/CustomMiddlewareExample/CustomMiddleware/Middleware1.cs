namespace CustomMiddlewareExample.CustomMiddleware
{
    public class Middleware1
    {
        private readonly RequestDelegate _next;

        public Middleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Example logging logic
            Console.WriteLine("Middleware1: Processing request.");
            await _next(context);
            Console.WriteLine("Middleware1: Processing response.");
        }
    }
}
