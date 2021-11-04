using Microsoft.EntityFrameworkCore;
using MyTodo.Models.EntityModels;

namespace MyTodo.Repositories.Db.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString: "DataSource=../MyTodo.Repositories/Db/Data/app.db;Cache=Shared");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasQueryFilter(t => t.DeletedAt == null);
        }
    }
}