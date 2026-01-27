using Microsoft.AspNetCore.Http;
using System.Buffers.Text;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace CustomMiddlewareExample.CustomMiddleware
{
    public class Middleware2
    {
        //Purpose:
        //  Stores a reference to the next middleware in the pipeline.
        //Role:
        //  Middleware needs to know what to do after it finishes its
        //job — this is the delegate it will call to forward the request to the next middleware (if allowed).
        private readonly RequestDelegate _next;


        //Purpose: Constructor for the middleware. ASP.NET Core automatically uses dependency injection to pass in the
        //RequestDelegate for the next middleware.
        //Role: Saves this delegate in the private field _next so it can be used later to forward the request down the pipeline.
        public Middleware2(RequestDelegate next)
        {
            _next = next;
        }

        //Purpose: This is the required method signature for middleware in ASP.NET Core.
        //Parameters:
            //HttpContext context → Provides access to everything about the current HTTP request and response(headers, body, status codes, etc.).
            //Role: When a request reaches this middleware, ASP.NET Core calls InvokeAsync so your custom logic runs.
        public async Task InvokeAsync(HttpContext context)
        {
        
            //Purpose: Reads the username and password values from the HTTP request headers.
            //Role:
                //These headers must be set by the client(e.g., Swagger, Postman).
                //No parsing from body or query string — it’s header-based authentication.
            string userName = context.Request.Headers["username"];
            string password =  context.Request.Headers["password"];

            if(userName== "Admin" && password == "Test123")
            {
                //Purpose:
                //Writes a message to the console for logging purposes.
                //Calls _next(context) → this forwards the request to the next middleware in the pipeline if
                //authentication is successful.
                //Role: This maintains the chain — the request keeps flowing if the user is authenticated.
                Console.WriteLine("Middleware2: Authentication passed.");
                await _next(context);
            }
            else
            {
                //Purpose:
                //Writes a message to the console for logging purposes.

                //Calls _next(context) → this forwards the request to the next middleware in the
                //pipeline if authentication is successful.
                //Role: This maintains the chain — the request keeps flowing if the user is authenticated.
                Console.WriteLine("Middleware2: Authentication failed. Terminating pipeline.");
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
            }
        }
    }
}

//Flow Summary
//Comes into Middleware2
//Reads username & password from request headers.
//If valid: Log success → pass request to the next middleware.
//If invalid: Log failure → immediately respond with 401 → stop processing.
