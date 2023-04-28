using Microsoft.EntityFrameworkCore;
using TodoList.Task.Data;
using TodoList.Task.Domain;
namespace TodoList.Context
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
     
        public TaskContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TaskModel().Configure(modelBuilder.Entity<TaskEntity>());
        }
    }
}
