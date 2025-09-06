using System;

namespace Todo.Application.DTOs
{
    public class TodoStatusDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
