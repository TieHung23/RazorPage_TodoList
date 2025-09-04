using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        public string TodoDetail { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime FinishedAt { get; set; }

        public TodoStatus Status { get; set; } = new TodoStatus();

        public bool IsDeleted { get; set; } = false;
    }
}
