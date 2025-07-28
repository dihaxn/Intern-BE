namespace TodoListAPI.Services
{
    /// <summary>
    /// Service interface for logging requests, responses, and errors.
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>Log an incoming request.</summary>
        void LogRequest(string method, string path, string? body);
        /// <summary>Log an outgoing response.</summary>
        void LogResponse(int statusCode, string response);
        /// <summary>Log an error.</summary>
        void LogError(string message, Exception? exception);
        /// <summary>Log an informational message.</summary>
        void LogInfo(string message);
    }
}