using System;
using MasterThesisASP.NET.Models;

namespace MasterThesisASP.NET.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<IEnumerable<User>> GetUsersWithTasksAsync();
    Task<User?> FindWithTasksAndCategoriesAsync(Guid userId);
}
