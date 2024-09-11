using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.Helpers.QueryObjects;
using MasterThesisASP.NET.Repositories.Interfaces;
using Task = MasterThesisASP.NET.Models.Task;
using Microsoft.EntityFrameworkCore;


namespace MasterThesisASP.NET.Repositories;

public class TaskRepository : BaseRepository<Task>, ITaskRepository
{
    public TaskRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Task>> FilterAsync(TaskQueryObject queryObject)
    {
        var tasks = context.Tasks.AsQueryable();

        if (queryObject.UserId.HasValue)
        {
            tasks = tasks.Where(t => t.UserId == queryObject.UserId.Value);
        }

        if (queryObject.CategoryId.HasValue)
        {
            tasks = tasks.Where(t => t.CategoryId == queryObject.CategoryId.Value);
        }

        if (!string.IsNullOrWhiteSpace(queryObject.Status))
        {
            var status = queryObject.Status.ToLower();
            tasks = tasks.Where(t => t.Status.ToString().ToLower() == status);
        }

        if (queryObject.DueBefore.HasValue)
        {
            tasks = tasks.Where(t => t.DueDate <= queryObject.DueBefore.Value);
        }

        tasks = queryObject.IsDescending
            ? tasks.OrderByDescending(t => t.DueDate)
            : tasks.OrderBy(t => t.DueDate);

        return await tasks.ToListAsync();
    }
}
