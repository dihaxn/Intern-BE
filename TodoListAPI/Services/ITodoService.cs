using TodoListAPI.Models;

namespace TodoListAPI.Services
{
    /// <summary>
    /// Service interface for managing todo items.
    /// </summary>
    public interface ITodoService
    {
        /// <summary>Get all todo items.</summary>
        Task<IEnumerable<TodoListAPI.Models.TodoItem>> GetAllTodosAsync();
        /// <summary>Get a todo item by its ID.</summary>
        Task<TodoListAPI.Models.TodoItem?> GetTodoByIdAsync(int id);
        /// <summary>Create a new todo item.</summary>
        Task<TodoListAPI.Models.TodoItem> CreateTodoAsync(TodoListAPI.Models.CreateTodoRequest request);
        /// <summary>Update an existing todo item.</summary>
        Task<TodoListAPI.Models.TodoItem?> UpdateTodoAsync(int id, TodoListAPI.Models.UpdateTodoRequest request);
        /// <summary>Delete a todo item by its ID.</summary>
        Task<bool> DeleteTodoAsync(int id);
        /// <summary>Toggle the completion status of a todo item.</summary>
        Task<bool> ToggleCompletionAsync(int id);
        /// <summary>Get todo items by category.</summary>
        Task<IEnumerable<TodoListAPI.Models.TodoItem>> GetTodosByCategoryAsync(string category);
        /// <summary>Get overdue todo items.</summary>
        Task<IEnumerable<TodoListAPI.Models.TodoItem>> GetOverdueTodosAsync();
        /// <summary>Get todo items by priority.</summary>
        Task<IEnumerable<TodoListAPI.Models.TodoItem>> GetTodosByPriorityAsync(TodoListAPI.Models.Priority priority);
        /// <summary>Get statistics about todo items.</summary>
        Task<object> GetTodoStatisticsAsync();
    }
}