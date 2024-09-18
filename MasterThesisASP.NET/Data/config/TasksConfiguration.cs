using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MasterThesisASP.NET.Enums;

using Task = MasterThesisASP.NET.Models.Task;
using TaskStatus = MasterThesisASP.NET.Enums.TaskStatus;

namespace MasterThesisASP.NET.Data.config;

public class TasksConfiguration : IEntityTypeConfiguration<Task>
{
    void IEntityTypeConfiguration<Task>.Configure(EntityTypeBuilder<Task> builder)
    {
         builder.HasData(
            new Task
            {
                Id = Guid.Parse("3e6c3bc7-1e64-4908-96b4-f4b5f84f9f3e"),
                Name = "Finish Report",
                Description = "Complete the annual report for 2024.",
                Status = TaskStatus.InProgress,
                DueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5)),
                UserId = Guid.Parse("c3fd4f55-22d5-4ed4-befc-9b5e2c0c4c6a"),
                CategoryId = Guid.Parse("8d3fd19b-07f0-4cae-9399-b404f45b3f58")
            },
            new Task
            {
                Id = Guid.Parse("6e73803d-b7e4-48bb-9c15-5d4b0be21d8d"),
                Name = "Implement asp.net application.",
                Description = "Finish master thesis.",
                Status = TaskStatus.Pending,
                DueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1)),
                UserId = Guid.Parse("f8d447e3-3183-40ff-9b71-7d9f60d4ad98"),
                CategoryId = Guid.Parse("062fedb0-b82e-4c6c-af1d-cf290a3f0d6c")
            }
        );
    }
}
