using System;

namespace TodoListAPI.Models
{
    /// <summary>
    /// Represents a todo item.
    /// </summary>
    public class TodoItem
    {
        /// <summary>Unique identifier</summary>
        public int Id { get; set; }
        /// <summary>Title of the todo item</summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>Description of the todo item</summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>Completion status</summary>
        public bool IsCompleted { get; set; }
        /// <summary>Creation date</summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>Date completed</summary>
        public DateTime? CompletedAt { get; set; }
        /// <summary>Priority level</summary>
        public Priority Priority { get; set; }
        /// <summary>Category of the todo item</summary>
        public string Category { get; set; } = string.Empty;
        /// <summary>Due date</summary>
        public DateTime? DueDate { get; set; }
        /// <summary>Last updated date</summary>
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Priority levels for a todo item.
    /// </summary>
    public enum Priority
    {
        /// <summary>Low priority</summary>
        Low = 0,
        /// <summary>Medium priority</summary>
        Medium = 1,
        /// <summary>High priority</summary>
        High = 2
    }
}
