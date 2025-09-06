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
        public AddTodo NewTodo { get; set; } = new AddTodo();

        [BindProperty]
        public UpdateTodo EditTodo { get; set; } = new UpdateTodo();

        [BindProperty]
        public Guid DeleteId { get; set; }

        private readonly ITodoService _service;
        private readonly IStatusService _statusService;

        [BindProperty]
        public Guid NewTodoStatusId { get; set; }

        [BindProperty]
        public Guid EditTodoStatusId { get; set; }

        public List<TodoStatusDto> Statuses { get; set; } = new();

        public TodoModel(ITodoService service, IStatusService statusService)
        {
            _service = service;
            _statusService = statusService;
        }

        public async Task OnGetAsync()
        {
            Todos = await _service.GetAllTodoItem();
            Statuses = await _statusService.GetAllStatuses();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            NewTodo.Status.Id = NewTodoStatusId;
            await _service.CreateTodoItem(NewTodo);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (ModelState.IsValid)
            {
                EditTodo.Status.Id = EditTodoStatusId;
                await _service.UpdateTodoItem(EditTodo);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await _service.DeleteTodoItem(new DeleteTodo { Id = DeleteId });
            return RedirectToPage();
        }
    }
}
