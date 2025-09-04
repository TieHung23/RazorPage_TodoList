using Todo.Domain.Models;

namespace Todo.Application.DTOs
{
    public class UpdateTodo
    {
        public Guid Id { get; set; }
        public string TodoDetail { get; set; } = string.Empty;
        public DateTime FinishedAt { get; set; }
        public TodoStatus Status { get; set; } = new TodoStatus();
    }
}
