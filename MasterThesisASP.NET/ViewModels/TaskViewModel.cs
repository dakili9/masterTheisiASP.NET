using System;

namespace MasterThesisASP.NET.ViewModels;

public class TaskViewModel
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateOnly DueDate { get; set; }
    public string? CategoryName { get; set; }
}
