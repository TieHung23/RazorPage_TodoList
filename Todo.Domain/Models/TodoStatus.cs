using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Models
{
    public class TodoStatus
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        public string Status { get; set; } = string.Empty;

        public ICollection<TodoItem> TodoItems { get; set; } = null!;
    }
}
