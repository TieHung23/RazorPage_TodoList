using Todo.Domain.Models;

namespace Todo.Application.DTOs
{
    public class AddTodo
    {
        public string TodoDetail { get; set; } = string.Empty;
        public DateTime FinishedAt { get; set; }
        public TodoStatus Status { get; set; } = new TodoStatus();
    }
}
