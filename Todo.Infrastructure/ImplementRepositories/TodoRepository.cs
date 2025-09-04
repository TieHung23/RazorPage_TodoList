using Microsoft.EntityFrameworkCore;
using Todo.Application.IRepositories;
using Todo.Domain.Models;
using Todo.Infrastructure.Database;

namespace Todo.Infrastructure.ImplementRepositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(TodoItem item)
        {
            var result = await _context.TodoItems.AddAsync(item);

            return result == null ? false : true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null) result.IsDeleted = true;

            var effected = await _context.SaveChangesAsync();

            return effected > 0 ? true : false;
        }

        public async Task<TodoItem> Get(Guid id)
        {
            var result = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

            return result!;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            var result = await _context.TodoItems.Where(x => x.IsDeleted != true).ToListAsync();

            return result;
        }

        public async Task<bool> Update(TodoItem item)
        {
            _context.TodoItems.Update(item);
            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
}
