using Todo.Domain.Models;

namespace Todo.Application.DTOs
{
    public class TodoResponse
    {
        public Guid Id { get; set; }

        public string TodoDetail { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime FinishedAt { get; set; }

        public TodoStatus Status { get; set; } = new TodoStatus();
    }
}
