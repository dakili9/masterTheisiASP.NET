namespace MasterThesisASP.NET.ViewModels;

public class UserTasksViewModel
{
    public string UserName { get; set; } = string.Empty;
    public IEnumerable<TaskViewModel> Tasks { get; set; } = Enumerable.Empty<TaskViewModel>();
}
