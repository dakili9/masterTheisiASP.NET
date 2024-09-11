using MasterThesisASP.NET.Dtos.Tasks;
using MasterThesisASP.NET.Enums;
using Task = MasterThesisASP.NET.Models.Task;

namespace MasterThesisASP.NET.Mappings;

public static class TasksMappings
{
    public static TaskDto ToTaskDto(this Task taskModel)
    {
        return new TaskDto
        {
            Id = taskModel.Id.ToString(),
            Name = taskModel.Name,
            Description = taskModel.Description,
            UserId = taskModel.UserId.ToString(),
            CategoryId = taskModel.CategoryId.ToString(),
            DueDate = taskModel.DueDate,
            Status = taskModel.Status?.GetStringValue()
        };
    }
}
