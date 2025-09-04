using Todo.Application.DTOs;
using Todo.Application.Helpers.TieHungMapper;
using Todo.Application.IRepositories;
using Todo.Application.IServices;
namespace Todo.Infrastructure.ImplementServices
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateTodoItem(AddTodo todo)
        {
            var item = TodoMapper.AddTodoItemConvert(todo);

            return await _repository.Add(item);
        }

        public async Task<bool> DeleteTodoItem(DeleteTodo todo)
        {
            return await _repository.Delete(todo.Id);
        }

        public async Task<List<TodoResponse>> GetAllTodoItem()
        {
            List<TodoResponse> result = (List<TodoResponse>)(await _repository.GetAll()).Select(x => TodoMapper.ConvertToTodoResponse(x));
            return result;
        }

        public async Task<TodoResponse> GetTodoItem(GetTodoByGuid id)
        {
            var result = (await _repository.Get(id.Id));

            var convertResult = TodoMapper.ConvertToTodoResponse(result);

            return convertResult;
        }

        public async Task<bool> UpdateTodoItem(UpdateTodo todo)
        {
            var todoItem = TodoMapper.UpdateTodoItemConvert(todo);

            return await _repository.Update(todoItem);
        }
    }
}
