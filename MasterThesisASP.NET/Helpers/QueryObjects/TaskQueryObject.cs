namespace MasterThesisASP.NET.Helpers.QueryObjects;

public class TaskQueryObject
{
    public Guid? UserId { get; set; }
    public Guid? CategoryId { get; set; }
    public string? Status { get; set; }
    public DateOnly? DueBefore { get; set; }
    public bool IsDescending { get; set; } = false;
}
