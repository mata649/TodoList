using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoList.Task.Domain.DTO
{
    public class UpdateTaskDTO
    {
        [JsonIgnore]
        public Guid ID { get; set; }

        [Required, MaxLength(60)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(250)]
        public string Description { get; set; } = string.Empty;


        public TaskEntity ToTask() => new() {ID= ID, Title = Title, Description = Description };
    }
}
