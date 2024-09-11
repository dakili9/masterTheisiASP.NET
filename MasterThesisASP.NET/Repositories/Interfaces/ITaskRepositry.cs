using MasterThesisASP.NET.Helpers.QueryObjects;
using Microsoft.AspNetCore.Identity;

using Task = MasterThesisASP.NET.Models.Task;

namespace MasterThesisASP.NET.Repositories.Interfaces;

public interface ITaskRepository : IBaseRepository<Task>
{
    Task<IEnumerable<Task>> FilterAsync(TaskQueryObject queryObject);
}
