using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.IRepositories;
using Todo.Application.IServices;
using Todo.Infrastructure.Database;
using Todo.Infrastructure.ImplementRepositories;
using Todo.Infrastructure.ImplementServices;

namespace Todo.Infrastructure.AddDependency
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            service.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Todo"));

            service.AddScoped<ITodoRepository, TodoRepository>();

            service.AddScoped<ITodoService, TodoService>();
        }
    }
}
