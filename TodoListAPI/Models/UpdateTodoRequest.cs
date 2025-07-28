using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Models
{
    /// <summary>
    /// Request model for updating a todo item.
    /// </summary>
    public class UpdateTodoRequest
    {
        /// <summary>Title of the todo item</summary>
        [StringLength(10)]
        public string? Title { get; set; }

        /// <summary>Description of the todo item</summary>
        [StringLength(1000)]
        public string? Description { get; set; }

        /// <summary>Completion status</summary>
        public bool? IsCompleted { get; set; }

        /// <summary>Priority of the todo item</summary>
        public Priority? Priority { get; set; }

        /// <summary>Due date of the todo item</summary>
        public DateTime? DueDate { get; set; }

        /// <summary>Category of the todo item</summary>
        [StringLength(10)]
        public string? Category { get; set; }
    }
}