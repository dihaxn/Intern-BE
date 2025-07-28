using TodoListAPI.Models;
using TodoListAPI.Services;
using System.Net;
using System.Text.Json;

namespace TodoListAPI.Middleware
{
    /// <summary>
    /// Middleware for handling global exceptions and returning standardized error responses.
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// Initializes a new instance of the GlobalExceptionMiddleware class.
        /// </summary>
        public GlobalExceptionMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// Handles the HTTP request and catches any unhandled exceptions.
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService>();
                
                loggingService.LogError("Global exception caught", ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            
            var response = new ApiResponse<object>
            {
                Success = false,
                Message = "An error occurred while processing your request."
            };

            switch (exception)
            {
                case ArgumentException argEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = argEx.Message;
                    response.Errors.Add("Invalid argument provided");
                    break;
                    
                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "The requested resource was not found.";
                    break;
                    
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response.Message = "You are not authorized to access this resource.";
                    break;
                    
                case InvalidOperationException invOpEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Invalid operation: " + invOpEx.Message;
                    break;
                    
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "An internal server error occurred.";
                    response.Errors.Add("Please try again later or contact support.");
                    break;
            }

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}