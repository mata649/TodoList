using Microsoft.AspNetCore.Mvc;
using TodoList.Common;
using TodoList.Task.Domain;
using TodoList.Task.Domain.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Task.Rest
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/tasks
        [HttpGet]
        public ActionResult Get([FromQuery] FiltersDTO filtersDTO)
        {   Console.WriteLine(filtersDTO.IsCompleted);
            IResponse response = _taskService.Get(filtersDTO);

            return StatusCode(response.Status, response.Value);
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {

            IResponse response = _taskService.GetById(id);

            return StatusCode(response.Status, response.Value);
        }

        // POST api/tasks
        [HttpPost]
        public ActionResult Create([FromBody] CreateTaskDTO createTaskDTO)
        {
            IResponse response = _taskService.Create(createTaskDTO);

            return StatusCode(response.Status, response.Value);
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] UpdateTaskDTO updateTaskDTO)
        {
            updateTaskDTO.ID = id;
            IResponse response = _taskService.Update(updateTaskDTO);
            return StatusCode(response.Status, response.Value);
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            IResponse response = _taskService.Delete(id);
            return StatusCode(response.Status, response.Value);
        }

        // PUT api/tasks/3/complete/
        [HttpPut("{id}/complete")]
        public ActionResult Update(Guid id)
        {
            IResponse response = _taskService.Complete(id);
            return StatusCode(response.Status, response.Value);
        }

    }
}
