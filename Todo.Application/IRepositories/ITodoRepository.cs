using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Models;

namespace Todo.Application.IRepositories
{
    public interface ITodoRepository
    {
        public Task<List<TodoItem>> GetAll();

        public Task<TodoItem> Get(Guid id);

        public Task<bool> Add(TodoItem item);

        public Task<bool> Update(TodoItem item);

        public Task<bool> Delete(Guid id);
    }
}
