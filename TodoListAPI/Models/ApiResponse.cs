namespace TodoListAPI.Models
{
    /// <summary>
    /// Standard API response wrapper.
    /// </summary>
    public class ApiResponse<T>
    {
        /// <summary>Indicates if the request was successful</summary>
        public bool Success { get; set; }
        /// <summary>Response message</summary>
        public string Message { get; set; } = string.Empty;
        /// <summary>Response data</summary>
        public T? Data { get; set; }
        /// <summary>List of error messages</summary>
        public List<string> Errors { get; set; } = new();
        /// <summary>Total count of items (for list responses)</summary>
        public int? TotalCount { get; set; }
    }
}