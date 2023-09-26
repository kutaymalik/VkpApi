using Microsoft.AspNetCore.Http;
using Vkp.Data.Services;


namespace Vkp.Data.Middlewares;
public class GlobalLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerService _logger;

    public GlobalLoggingMiddleware(RequestDelegate next, ILoggerService logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // You can log when the request starts
            _logger.Log($"Request started: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            // You can log when the response is completed.
            _logger.Log($"Response completed: {context.Response.StatusCode}");
        }
        catch (Exception ex)
        {
            // You can log in case of errors
            _logger.Log($"An error occurred: {ex.Message}");
            throw; // Reporting the error upwards
        }
    }
}
