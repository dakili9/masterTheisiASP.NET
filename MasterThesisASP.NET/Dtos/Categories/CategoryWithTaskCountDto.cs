using System;

namespace MasterThesisASP.NET.Dtos.Categories;

public class CategoryWithTaskCountDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TaskCount { get; set; }
}
