using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Application.DTOs;

namespace Todo.Application.IServices
{
    public interface IStatusService
    {
        Task<List<TodoStatusDto>> GetAllStatuses();
    }
}
