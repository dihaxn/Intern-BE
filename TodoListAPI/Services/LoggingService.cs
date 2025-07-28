namespace TodoListAPI.Services
{
    /// <summary>
    /// Implementation of ILoggingService for logging requests, responses, and errors.
    /// </summary>
    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        /// <summary>
        /// Initializes a new instance of the LoggingService class.
        /// </summary>
        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public void LogRequest(string method, string path, string? body)
        {
            _logger.LogInformation("📥 Request: {Method} {Path} | Body: {Body}", 
                method, path, body ?? "No body");
        }

        /// <inheritdoc/>
        public void LogResponse(int statusCode, string response)
        {
            _logger.LogInformation("📤 Response: {StatusCode} | Body: {Response}", 
                statusCode, response.Length > 500 ? response[..500] + "..." : response);
        }

        /// <inheritdoc/>
        public void LogError(string message, Exception? exception)
        {
            _logger.LogError(exception, "❌ Error: {Message}", message);
        }

        /// <inheritdoc/>
        public void LogInfo(string message)
        {
            _logger.LogInformation("ℹ️ Info: {Message}", message);
        }
    }
}