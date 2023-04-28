namespace TodoList.Task.Domain
{
    public class TaskEntity
    {
        public Guid ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
