using TodoList.Common;
using TodoList.Task.Domain.DTO;

namespace TodoList.Task.Domain
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger _logger;
        public TaskService(ITaskRepository taskRepository, ILogger<TaskService> logger)
        {
            this._taskRepository = taskRepository;
            this._logger = logger;
        }

        public IResponse Complete(Guid id)
        {
            try
            {
                TaskEntity? taskFound = _taskRepository.GetById(id);

                if (taskFound is null) return new ResponseFailure("Task was not found", 404);

                taskFound.IsCompleted = !taskFound.IsCompleted;

                taskFound.CompletedDate = taskFound.IsCompleted ? DateTime.UtcNow : new DateTime();

                _taskRepository.Update(taskFound);

                return new ResponseSuccess(taskFound, 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error completing a task", ex.Message);
                return new ResponseFailure("Internal Error", 500);

            }
        }

        public IResponse Create(CreateTaskDTO createTaskDTO)
        {
            try
            {
                TaskEntity task = createTaskDTO.ToTask();
                _taskRepository.Create(task);

                return new ResponseSuccess(task, 201);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating a task", ex.Message);
                return new ResponseFailure("Internal Error", 500);

            }
        }

        public IResponse Delete(Guid id)
        {
            try
            {
                TaskEntity? taskFound = _taskRepository.GetById(id);

                if (taskFound is null) return new ResponseFailure("Task was not found", 404);

                _taskRepository.Delete(id);

                return new ResponseSuccess(taskFound, 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting a task", ex.Message);
                return new ResponseFailure("Internal Error", 500);

            }
        }

        public IResponse GetById(Guid id)
        {
            try
            {
                TaskEntity? taskFound = _taskRepository.GetById(id);

                if (taskFound is null) return new ResponseFailure("Task was not found", 404);

                return new ResponseSuccess(taskFound, 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error finding a task", ex.Message);
                return new ResponseFailure("Internal Error", 500);

            }
        }

        public IResponse Update(UpdateTaskDTO updateTaskDTO)
        {
            try
            {
                TaskEntity task = updateTaskDTO.ToTask();

                TaskEntity? taskFound = _taskRepository.GetById(task.ID);

                if (taskFound is null) return new ResponseFailure("Task was not found", 404);

                taskFound.Title = task.Title;
                taskFound.Description = task.Description;
                _taskRepository.Update(taskFound);
                return new ResponseSuccess(taskFound, 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating a task", ex.Message);
                return new ResponseFailure("Internal Error", 500);

            }
        }

        public IResponse Get(FiltersDTO filters)
        {
            try
            {
                IEnumerable<TaskEntity> taskFound = _taskRepository.Get(filters);

                return new ResponseSuccess(taskFound, 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting tasks", ex.Message);
                return new ResponseFailure("Internal Error", 500);

            }
        }


    }
}
