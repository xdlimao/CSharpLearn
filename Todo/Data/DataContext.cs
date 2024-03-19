using Microsoft.EntityFrameworkCore;
using Todo.Models;


namespace Todo.Data
{
    public class DataContext : DbContext
    {
            public DbSet<TodoModel> Todos { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}

