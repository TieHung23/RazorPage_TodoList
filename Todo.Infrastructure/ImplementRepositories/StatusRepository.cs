using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Application.IRepositories;
using Todo.Domain.Models;
using Todo.Infrastructure.Database;

namespace Todo.Infrastructure.ImplementRepositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoStatus>> GetAll()
        {
            return await _context.TodoStatuses.ToListAsync();
        }
    }
}
