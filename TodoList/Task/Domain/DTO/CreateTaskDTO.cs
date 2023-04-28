using System.ComponentModel.DataAnnotations;

namespace TodoList.Task.Domain.DTO
{
    public class CreateTaskDTO
    {
        [Required, MaxLength(60)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(250)]
        public string Description { get; set; } = string.Empty;

        public TaskEntity ToTask() => new() { Title = Title, Description = Description, IsCompleted = false, RegisteredDate = DateTime.UtcNow, CompletedDate = new DateTime() };
    }
}
