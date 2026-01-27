//This file is just to explain the middlewares and the pipeline using in this project

/*
Idea of Middleware1, Middleware2, and Middleware3 to the request pipeline concept in ASP.NET Core. Let’s break it down.

1. Understanding the Pipeline
    In ASP.NET Core, the middleware pipeline is like a sequence of steps that every HTTP request passes 
    through before getting a response.

    Think of it like a water pipe with several filters:
        Water (HTTP request) enters the pipe.
        It passes through filters (middlewares) one by one in the order they are registered.
        Each filter can:
        Do something before passing water to the next filter.
        Do something after the water comes back (response).
        Stop the water completely (short-circuit), never letting it reach the rest.

    In your code:
        Middleware1 (Logging) → logs before and after the request.
        Middleware2 (Authentication) → checks credentials and either allows or stops the request.
        Middleware3 (Terminal) → returns the final data (response).

2. How Your Middlewares Work in the Pipeline
    Step-by-step request flow
        
        HTTP Request enters the app
           ASP.NET Core starts at the top of the registered middleware list.
        
        Middleware1 runs
            Logs the incoming request.
            Calls await _next(context) → passes control to Middleware2.
            After Middleware2 and Middleware3 finish, Middleware1 logs the response.

        Middleware2 runs
            Reads username and password from request headers.
            If correct → Calls _next(context) → lets request go to Middleware3.
            If incorrect → Stops (short-circuits), sends back 401 Unauthorized → Middleware3 never runs.
        
        Middleware3 (Terminal) runs
            Generates "Hello from Middleware3" response.
            Does NOT call _next(context) → ends the request pipeline.

3. Response Flow
        If Middleware3 is reached, it sends the response back.
        The outgoing response passes backwards through the pipeline:
        Goes from Middleware3 → Middleware2 → Middleware1.
        Each middleware along the way could modify the response.
*/