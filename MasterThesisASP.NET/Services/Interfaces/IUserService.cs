using System;
using MasterThesisASP.NET.Models;

namespace MasterThesisASP.NET.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    Task<User> GetUserWithTasksAndCategoriesAsync(Guid userId);
}
