using Microsoft.EntityFrameworkCore;
using TodoList.Task.Domain;
using TodoList.Context;
using TodoList.Task.Domain.DTO;

namespace TodoList.Task.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;
        private readonly DbSet<TaskEntity> _tasks;

        public TaskRepository(TaskContext context)
        {
            _context = context;
            _tasks = context.Set<TaskEntity>();
        }

        public void Create(TaskEntity task)
        {
            _tasks.Add(task);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            TaskEntity? task = _tasks.Find(id);
            if (task is not null)
            {
                _tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TaskEntity> Get(FiltersDTO filters)
        {
            var tasks = _tasks.AsQueryable();
            if (filters.IsCompleted is bool isCompleted) tasks = tasks.Where(t => t.IsCompleted == isCompleted);
            return tasks.ToList();
        }

        public TaskEntity? GetById(Guid id)
        {
            return _tasks.Find(id);
        }

        public void Update(TaskEntity task)
        {
            _tasks.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
