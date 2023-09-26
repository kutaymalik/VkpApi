using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Vkp.Data.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Continue the request chain
            await _next(context);
        }
        catch (Exception ex)
        {
            // Here you can handle the exception and return an appropriate response.
            // For example, you can create a response with an error message or HTTP status code.
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsync($"Global Exception: {ex.Message}");
        }
    }
}
