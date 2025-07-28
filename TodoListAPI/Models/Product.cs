using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Models
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product
    {
        /// <summary>Unique identifier</summary>
        public int Id { get; set; }

        /// <summary>Title of the product</summary>
        [Required]
        [StringLength(10, ErrorMessage = "Title cannot exceed 10 characters")]
        public string Title { get; set; } = string.Empty;

        /// <summary>Description of the product</summary>
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; } = string.Empty;

        /// <summary>Completion status</summary>
        public bool IsCompleted { get; set; } = false;

        /// <summary>Priority of the product</summary>
        [Required]
        public Priority Priority { get; set; } = Priority.Medium;

        /// <summary>Due date of the product</summary>
        public DateTime? DueDate { get; set; }

        /// <summary>Creation date</summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        /// <summary>Last updated date</summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>Category of the product</summary>
        [StringLength(10)]
        public string Category { get; set; } = "General";
    }

}