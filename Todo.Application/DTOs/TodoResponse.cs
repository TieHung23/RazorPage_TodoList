using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Models;

namespace Todo.Application.DTOs
{
    public class TodoResponse
    {
        public string TodoDetail { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime FinishedAt { get; set; }

        public TodoStatus Status { get; set; } = new TodoStatus();
    }
}
