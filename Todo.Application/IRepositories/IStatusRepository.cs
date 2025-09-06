using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Models;

namespace Todo.Application.IRepositories
{
    public interface IStatusRepository
    {
        Task<List<TodoStatus>> GetAll();
    }
}
