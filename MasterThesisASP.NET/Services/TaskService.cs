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

    public async Task<Models.Task> CreateAsync(CreateRequestDto taskDto)
    {
        if(taskDto is CreateTaskRequestDto dto) 
        {
            await CheckIfUserAndCategoryExist(dto.UserId, dto.CategoryId);

            var task = new Task
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Status = dto.Status,
                DueDate = dto.DueDate,
                UserId = dto.UserId,
                CategoryId = dto.CategoryId
            };

            return await taskRepository.CreateAsync(task);
        }

        throw new ArgumentException("Invalid DTO type for Task create");
    }


    public async Task<bool> DeleteAsync(Guid id)
    {
        Task? task = await taskRepository.GetByIdAsync(id);

        if(task is null)
        {
            //todo throw exception
        }

        return await taskRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Models.Task>> FilterAsync(TaskQueryObject queryObject)
    {
        return await taskRepository.FilterAsync(queryObject);
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
            //todo throw exception
        }

        return task;
    }

    public async Task<Models.Task> UpdateAsync(Guid id, UpdateRequestDto taskDto)
    {
        Task? task = await taskRepository.GetByIdAsync(id);
        
        if(task is null)
        {
            //todo throw exception
        }

        if (taskDto is UpdateTaskRequestDto dto)
        {
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

    private async System.Threading.Tasks.Task CheckIfUserAndCategoryExist(Guid userId, Guid? categoryId)
    {
        if (!await userRepository.ExistsAsync(userId))
        {
            throw new Exception("User not found");
        }

        if (categoryId.HasValue && !await categoryRepository.ExistsAsync(categoryId.Value))
        {
            throw new Exception("Category not found");
        }
    }
}
