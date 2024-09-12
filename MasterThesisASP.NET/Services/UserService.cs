using System;
using MasterThesisASP.NET.Dtos.Abstract;
using MasterThesisASP.NET.Dtos.Users;
using MasterThesisASP.NET.Exceptions;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Repositories.Interfaces;
using MasterThesisASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MasterThesisASP.NET.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public Task<User> CreateAsync(CreateRequestDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
         return await userRepository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new NotFoundException($"User with id {id} not found.");
        }

        return user;
    }

    public Task<User> GetUserWithTasksAndCategoriesAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(Guid id, UpdateRequestDto entity)
    {
        throw new NotImplementedException();
    }
}
