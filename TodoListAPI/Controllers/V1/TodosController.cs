using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers.V1
{
    /// <summary>
    /// Controller for managing V1 todo endpoints.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/todos")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILoggingService _loggingService;

        /// <summary>
        /// Initializes a new instance of the TodosController class.
        /// </summary>
        public TodosController(ITodoService todoService, ILoggingService loggingService)
        {
            _todoService = todoService;
            _loggingService = loggingService;
        }

        /// <summary>
        /// Get all todo items
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<TodoItem>>>> GetTodos()
        {
            var todos = await _todoService.GetAllTodosAsync();

            return Ok(new ApiResponse<IEnumerable<TodoItem>>
            {
                Success = true,
                Message = "Todos retrieved successfully",
                Data = todos,
                TotalCount = todos.Count()
            });
        }

        /// <summary>
        /// Get a specific todo item by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<TodoItem>>> GetTodo(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);

            if (todo == null)
            {
                return NotFound(new ApiResponse<TodoItem>
                {
                    Success = false,
                    Message = $"Todo with ID {id} not found"
                });
            }

            return Ok(new ApiResponse<TodoItem>
            {
                Success = true,
                Message = "Todo retrieved successfully",
                Data = todo
            });
        }

        /// <summary>
        /// Create a new todo item
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<TodoItem>>> CreateTodo([FromBody] CreateTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<TodoItem>
                {
                    Success = false,
                    Message = "Invalid todo data",
                    Errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList()
                });
            }

            var createdTodo = await _todoService.CreateTodoAsync(request);
            _loggingService.LogInfo($"Todo created with ID: {createdTodo.Id}");

            return CreatedAtAction(nameof(GetTodo),
                new { id = createdTodo.Id },
                new ApiResponse<TodoItem>
                {
                    Success = true,
                    Message = "Todo created successfully",
                    Data = createdTodo
                });
        }

        /// <summary>
        /// Update an existing todo item
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<TodoItem>>> UpdateTodo(int id, [FromBody] UpdateTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<TodoItem>
                {
                    Success = false,
                    Message = "Invalid todo data",
                    Errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList()
                });
            }

            var updatedTodo = await _todoService.UpdateTodoAsync(id, request);

            if (updatedTodo == null)
            {
                return NotFound(new ApiResponse<TodoItem>
                {
                    Success = false,
                    Message = $"Todo with ID {id} not found"
                });
            }

            _loggingService.LogInfo($"Todo updated with ID: {id}");

            return Ok(new ApiResponse<TodoItem>
            {
                Success = true,
                Message = "Todo updated successfully",
                Data = updatedTodo
            });
        }

        /// <summary>
        /// Delete a todo item
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteTodo(int id)
        {
            var deleted = await _todoService.DeleteTodoAsync(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Todo with ID {id} not found"
                });
            }

            _loggingService.LogInfo($"Todo deleted with ID: {id}");

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Todo deleted successfully"
            });
        }

        /// <summary>
        /// Toggle completion status of a todo item
        /// </summary>
        [HttpPatch("{id}/toggle")]
        public async Task<ActionResult<ApiResponse<object>>> ToggleTodoCompletion(int id)
        {
            var toggled = await _todoService.ToggleCompletionAsync(id);

            if (!toggled)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Todo with ID {id} not found"
                });
            }

            _loggingService.LogInfo($"Todo completion toggled for ID: {id}");

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Todo completion status toggled successfully"
            });
        }
    }
}
