using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Application.DTOs;
using Todo.Application.IRepositories;
using Todo.Application.IServices;

namespace Todo.Infrastructure.ImplementServices
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoStatusDto>> GetAllStatuses()
        {
            var statuses = await _repository.GetAll();
            return statuses.Select(s => new TodoStatusDto { Id = s.Id, Status = s.Status }).ToList();
        }
    }
}
