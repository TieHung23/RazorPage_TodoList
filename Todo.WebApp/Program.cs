using Todo.Infrastructure.AddDependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructure();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Seed dummy data for statuses and todo items, and log to terminal
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    var db = services.GetService<Todo.Infrastructure.Database.AppDbContext>();
    if (db != null)
    {
        // Seed dummy statuses if not present
        if (!db.TodoStatuses.Any())
        {
            var status1 = new Todo.Domain.Models.TodoStatus { Id = Guid.NewGuid(), Status = "Pending" };
            var status2 = new Todo.Domain.Models.TodoStatus { Id = Guid.NewGuid(), Status = "In Progress" };
            var status3 = new Todo.Domain.Models.TodoStatus { Id = Guid.NewGuid(), Status = "Completed" };
            db.TodoStatuses.AddRange(status1, status2, status3);
            db.SaveChanges();
            logger.LogInformation("Seeded TodoStatuses: {Statuses}", db.TodoStatuses.Select(s => s.Status).ToList());
        }

        // Seed dummy todos if not present
        if (!db.TodoItems.Any())
        {
            var statuses = db.TodoStatuses.ToList();
            db.TodoItems.AddRange(
                new Todo.Domain.Models.TodoItem
                {
                    Id = Guid.NewGuid(),
                    TodoDetail = "Buy groceries",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    FinishedAt = DateTime.Now.AddDays(2),
                    Status = statuses[0]
                },
                new Todo.Domain.Models.TodoItem
                {
                    Id = Guid.NewGuid(),
                    TodoDetail = "Finish project",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    FinishedAt = DateTime.Now.AddDays(5),
                    Status = statuses[1]
                }
            );
            db.SaveChanges();
            logger.LogInformation("Seeded TodoItems: {Todos}", db.TodoItems.Select(t => t.TodoDetail).ToList());
        }
    }
}

app.Run();
