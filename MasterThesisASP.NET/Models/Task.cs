using TaskStatus = MasterThesisASP.NET.Enums.TaskStatus;

namespace MasterThesisASP.NET.Models;

public class Task
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public TaskStatus? Status { get; set; }
    public string? Description { get; set; }
    public DateOnly DueDate { get; set; }
    public required Guid UserId { get; set; }
    public User User { get; set; }
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
}

