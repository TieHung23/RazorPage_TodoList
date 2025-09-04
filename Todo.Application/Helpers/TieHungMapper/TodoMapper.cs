using Todo.Application.DTOs;
using Todo.Domain.Models;

namespace Todo.Application.Helpers.TieHungMapper
{
    public static class TodoMapper
    {
        public static TodoResponse ConvertToTodoResponse(TodoItem item)
        {
            return new TodoResponse
            {
                TodoDetail = item.TodoDetail,
                CreatedAt = item.CreatedAt,
                FinishedAt = item.FinishedAt,
                Status = item.Status
            };
        }

        public static TodoItem AddTodoItemConvert(AddTodo item)
        {
            return new TodoItem
            {
                FinishedAt = item.FinishedAt,
                TodoDetail = item.TodoDetail,
                Status = item.Status
            };
        }

        public static TodoItem UpdateTodoItemConvert(UpdateTodo item)
        {
            return new TodoItem
            {
                Id = item.Id,
                TodoDetail = item.TodoDetail,
                FinishedAt = item.FinishedAt,
                Status = item.Status
            };
        }

    }
}
