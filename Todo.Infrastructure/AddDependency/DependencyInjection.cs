using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Infrastructure.Database;

namespace Todo.Infrastructure.AddDependency
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            service.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Todo"));
        }
    }
}
