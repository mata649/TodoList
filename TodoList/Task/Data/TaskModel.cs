using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Task.Domain;

namespace TodoList.Task.Data
{
    public class TaskModel : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(60);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(250);
            builder.Property(t => t.IsCompleted).IsRequired().HasDefaultValue(false);
            builder.Property(t=>t.RegisteredDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(t => t.CompletedDate).IsRequired(true).HasDefaultValue(new DateTime());
        }
    }
}
