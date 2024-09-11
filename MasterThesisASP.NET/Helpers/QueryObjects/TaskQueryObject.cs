namespace MasterThesisASP.NET.Helpers.QueryObjects;

public class TaskQueryObject
{
    public Guid? UserId { get; set; }
    public Guid? CategoryId { get; set; }
    public string? Status { get; set; }
    public DateTime? DueBefore { get; set; }
    public bool IsDescending { get; set; } = false;
}
