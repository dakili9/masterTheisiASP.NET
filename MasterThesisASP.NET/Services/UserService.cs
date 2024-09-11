using System;
using MasterThesisASP.NET.Dtos.Abstract;
using MasterThesisASP.NET.Dtos.Users;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Services.Interfaces;

namespace MasterThesisASP.NET.Services;

public class UserService : IUserService
{
    public Task<User> CreateAsync(CreateRequestDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(Guid id, UpdateRequestDto entity)
    {
        throw new NotImplementedException();
    }
}
