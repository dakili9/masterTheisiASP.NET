using MasterThesisASP.NET.Helpers.QueryObjects;
using Task = MasterThesisASP.NET.Models.Task;

namespace MasterThesisASP.NET.Services.Interfaces;

public interface ITaskService : IBaseService<Task>
{
     Task<IEnumerable<Task>> FilterAsync(TaskQueryObject queryObject);
}
