using System;

namespace MasterThesisASP.NET.Dtos.Tasks;

public class TaskDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateOnly DueDate { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string? CategoryId { get; set; } = string.Empty;
}
