using MasterThesisASP.NET.Dtos.Abstract;
using MasterThesisASP.NET.Dtos.Tasks;
using MasterThesisASP.NET.Helpers.QueryObjects;
using MasterThesisASP.NET.Repositories.Interfaces;
using MasterThesisASP.NET.Services.Interfaces;

using Task = MasterThesisASP.NET.Models.Task;

namespace MasterThesisASP.NET.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository taskRepository;
    private readonly ICategoryRepository categoryRepository;
    private readonly IUserRepository userRepository;

    public TaskService(
        ITaskRepository taskRepository,
        ICategoryRepository categoryRepository,
        IUserRepository userRepository)
    {
        this.taskRepository = taskRepository;
        this.categoryRepository = categoryRepository;
        this.userRepository = userRepository;
    }

    public Task<Models.Task> CreateAsync(CreateRequestDto taskDto)
    {
        throw new NotImplementedException();
    }


    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Models.Task>> FilterAsync(TaskQueryObject queryObject)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Models.Task>> GetAllAsync()
    {
        return await taskRepository.GetAllAsync();
    }

    public async Task<Models.Task> GetByIdAsync(Guid id)
    {
        Task? task = await taskRepository.GetByIdAsync(id);

        if(task is null)
        {
            // throw exception
        }

        return task;
    }

    public async Task<Models.Task> UpdateAsync(Guid id, UpdateRequestDto taskDto)
    {
        Task? task = await taskRepository.GetByIdAsync(id);
        
        if(task is null)
        {
            //throw exception
        }

        if (taskDto is UpdateTaskRequestDto dto){
            task.Name = dto.Name;
            task.Description = dto.Description;
            task.Status = dto.Status;
            task.DueDate = dto.DueDate;
            task.UserId = dto.UserId;
            task.CategoryId = dto.CategoryId;

        return await taskRepository.UpdateAsync(task);
        }

        throw new ArgumentException("Invalid DTO type for Task update");
    }

}
