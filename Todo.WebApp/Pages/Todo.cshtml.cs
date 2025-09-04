using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo.Application.DTOs;
using Todo.Application.IServices;

namespace Todo.WebApp.Pages
{
    public class TodoModel : PageModel
    {
        [BindProperty]
        public List<TodoResponse> Todos { get; set; } = new List<TodoResponse>();

        [BindProperty]
        public TodoResponse Todo { get; set; } = new TodoResponse();

        [BindProperty]
        public List<StatusResponse> Statuses { get; set; } = new List<StatusResponse>();
        private readonly ITodoService _service;

        public TodoModel(ITodoService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            Todos = await _service.GetAllTodoItem();
        }
    }
}
