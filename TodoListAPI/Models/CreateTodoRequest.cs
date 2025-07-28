using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Models
{
    /// <summary>
    /// Request model for creating a todo item.
    /// </summary>
    public class CreateTodoRequest
    {
        /// <summary>Title of the todo item</summary>
        [Required]
        [StringLength(10)]
        public string Title { get; set; } = string.Empty;

        /// <summary>Description of the todo item</summary>
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        /// <summary>Priority of the todo item</summary>
        public Priority Priority { get; set; } = Priority.Medium;

        /// <summary>Due date of the todo item</summary>
        public DateTime? DueDate { get; set; }

        /// <summary>Category of the todo item</summary>
        [StringLength(10)]
        public string Category { get; set; } = "General";
    }
}