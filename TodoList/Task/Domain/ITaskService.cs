using TodoList.Common;
using TodoList.Task.Domain.DTO;

namespace TodoList.Task.Domain
{
    public interface ITaskService
    {
        public IResponse Create(CreateTaskDTO createTaskDTO);
        public IResponse Update(UpdateTaskDTO updateTaskDTO);
        public IResponse Delete(Guid id);
        public IResponse GetById(Guid id);
        public IResponse Complete(Guid id);
        public IResponse Get(FiltersDTO filters);
    }
}
