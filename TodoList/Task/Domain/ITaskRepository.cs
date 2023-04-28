using TodoList.Task.Domain.DTO;

namespace TodoList.Task.Domain
{
    public interface ITaskRepository
    {
        void Create(TaskEntity task);
        TaskEntity? GetById(Guid id);
        IEnumerable<TaskEntity> Get(FiltersDTO filters);
        void Delete(Guid id);
        void Update(TaskEntity entity);
        

    }
}
