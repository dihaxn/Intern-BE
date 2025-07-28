using TodoListAPI.Services;
using System.Text;

namespace TodoListAPI.Middleware
{
    /// <summary>
    /// Middleware for logging HTTP requests and responses.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// Initializes a new instance of the RequestLoggingMiddleware class.
        /// </summary>
        public RequestLoggingMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// Handles the HTTP request and logs request and response details.
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService>();

            // Skip logging for health checks and swagger
            if (context.Request.Path.StartsWithSegments("/health") || 
                context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            // Log request
            var requestBody = await ReadRequestBodyAsync(context.Request);
            loggingService.LogRequest(
                context.Request.Method, 
                context.Request.Path, 
                requestBody
            );

            // Capture response
            var originalResponseBody = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            var startTime = DateTime.UtcNow;
            await _next(context);
            var duration = DateTime.UtcNow - startTime;

            // Log response
            responseBody.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(responseBody).ReadToEndAsync();
            loggingService.LogResponse(context.Response.StatusCode, response);
            loggingService.LogInfo($"Request completed in {duration.TotalMilliseconds}ms");

            // Copy response back to original stream
            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalResponseBody);
        }

        /// <summary>
        /// Reads the request body as a string.
        /// </summary>
        private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            if (request.ContentLength == 0 || request.ContentLength == null) 
                return string.Empty;

            request.EnableBuffering();
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            return body;
        }
    }
}
