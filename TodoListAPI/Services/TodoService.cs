using TodoListAPI.Models;

namespace TodoListAPI.Services
{
    /// <summary>
    /// In-memory implementation of ITodoService for managing todo items.
    /// </summary>
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _todos;
        private int _nextId = 1;

        /// <summary>
        /// Initializes a new instance of the TodoService class with sample data.
        /// </summary>
        public TodoService()
        {
            // Initialize with sample data
            _todos = new List<TodoItem>
            {
                new TodoItem 
                { 
                    Id = _nextId++, 
                    Title = "Complete ASP.NET Core tutorial", 
                    Description = "Learn controllers, middleware, and DI",
                    Priority = Priority.High,
                    Category = "Learning",
                    DueDate = DateTime.UtcNow.AddDays(3)
                },
                new TodoItem 
                { 
                    Id = _nextId++, 
                    Title = "Buy groceries", 
                    Description = "Milk, eggs, bread, and fruits",
                    Priority = Priority.Medium,
                    Category = "Personal",
                    DueDate = DateTime.UtcNow.AddDays(1)
                },
                new TodoItem 
                { 
                    Id = _nextId++, 
                    Title = "Review pull requests", 
                    Description = "Check team's code submissions",
                    Priority = Priority.High,
                    Category = "Work",
                    IsCompleted = true
                },
                new TodoItem 
                { 
                    Id = _nextId++, 
                    Title = "Plan weekend trip", 
                    Description = "Research destinations and book hotels",
                    Priority = Priority.Low,
                    Category = "Personal",
                    DueDate = DateTime.UtcNow.AddDays(7)
                }
            };
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            await Task.Delay(10); // Simulate async operation
            return _todos.OrderByDescending(t => t.CreatedAt).ToList();
        }

        /// <inheritdoc/>
        public async Task<TodoItem?> GetTodoByIdAsync(int id)
        {
            await Task.Delay(10);
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        /// <inheritdoc/>
        public async Task<TodoItem> CreateTodoAsync(CreateTodoRequest request)
        {
            await Task.Delay(10);
            
            var todo = new TodoItem
            {
                Id = _nextId++,
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                Category = request.Category,
                DueDate = request.DueDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _todos.Add(todo);
            return todo;
        }

        /// <inheritdoc/>
        public async Task<TodoItem?> UpdateTodoAsync(int id, UpdateTodoRequest request)
        {
            await Task.Delay(10);
            
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return null;

            // Update only provided fields
            if (!string.IsNullOrEmpty(request.Title))
                todo.Title = request.Title;
            
            if (request.Description != null)
                todo.Description = request.Description;
            
            if (request.IsCompleted.HasValue)
                todo.IsCompleted = request.IsCompleted.Value;
            
            if (request.Priority.HasValue)
                todo.Priority = request.Priority.Value;
            
            if (request.DueDate.HasValue)
                todo.DueDate = request.DueDate.Value;
            
            if (!string.IsNullOrEmpty(request.Category))
                todo.Category = request.Category;

            todo.UpdatedAt = DateTime.UtcNow;
            return todo;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteTodoAsync(int id)
        {
            await Task.Delay(10);
            
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return false;

            _todos.Remove(todo);
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> ToggleCompletionAsync(int id)
        {
            await Task.Delay(10);
            
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return false;

            todo.IsCompleted = !todo.IsCompleted;
            todo.UpdatedAt = DateTime.UtcNow;
            return true;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TodoItem>> GetTodosByCategoryAsync(string category)
        {
            await Task.Delay(10);
            return _todos.Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(t => t.CreatedAt)
                        .ToList();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TodoItem>> GetOverdueTodosAsync()
        {
            await Task.Delay(10);
            var now = DateTime.UtcNow;
            return _todos.Where(t => !t.IsCompleted && t.DueDate.HasValue && t.DueDate.Value < now)
                        .OrderBy(t => t.DueDate)
                        .ToList();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TodoItem>> GetTodosByPriorityAsync(Priority priority)
        {
            await Task.Delay(10);
            return _todos.Where(t => t.Priority == priority)
                        .OrderByDescending(t => t.CreatedAt)
                        .ToList();
        }

        /// <inheritdoc/>
        public async Task<object> GetTodoStatisticsAsync()
        {
            await Task.Delay(10);
            
            var totalTodos = _todos.Count;
            var completedTodos = _todos.Count(t => t.IsCompleted);
            var pendingTodos = totalTodos - completedTodos;
            var overdueTodos = _todos.Count(t => !t.IsCompleted && t.DueDate.HasValue && t.DueDate.Value < DateTime.UtcNow);
            
            var categories = _todos.GroupBy(t => t.Category)
                                  .Select(g => new { Category = g.Key, Count = g.Count() })
                                  .OrderByDescending(c => c.Count)
                                  .ToList();

            var priorityBreakdown = _todos.GroupBy(t => t.Priority)
                                         .Select(g => new { Priority = g.Key.ToString(), Count = g.Count() })
                                         .OrderByDescending(p => p.Count)
                                         .ToList();

            return new
            {
                TotalTodos = totalTodos,
                CompletedTodos = completedTodos,
                PendingTodos = pendingTodos,
                OverdueTodos = overdueTodos,
                CompletionRate = totalTodos > 0 ? Math.Round((double)completedTodos / totalTodos * 100, 2) : 0,
                Categories = categories,
                PriorityBreakdown = priorityBreakdown,
                RecentActivity = _todos.OrderByDescending(t => t.UpdatedAt).Take(5).Select(t => new 
                {
                    t.Id,
                    t.Title,
                    t.IsCompleted,
                    t.UpdatedAt
                }).ToList()
            };
        }
    }
}
