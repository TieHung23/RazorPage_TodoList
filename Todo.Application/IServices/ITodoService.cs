using Todo.Application.DTOs;

namespace Todo.Application.IServices
{
    public interface ITodoService
    {
        public Task<List<TodoResponse>> GetAllTodoItem();

        public Task<TodoResponse> GetTodoItem(GetTodoByGuid id);

        public Task<bool> CreateTodoItem(AddTodo todo);

        public Task<bool> UpdateTodoItem(UpdateTodo todo);

        public Task<bool> DeleteTodoItem(DeleteTodo todo);
    }
}
