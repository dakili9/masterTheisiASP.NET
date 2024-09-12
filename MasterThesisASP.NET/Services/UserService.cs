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
    private readonly UserManager<User> userManager;
    private readonly IUserRepository userRepository;

    public UserService(
        IUserRepository userRepository,
        UserManager<User> userManager)
    {
        this.userRepository = userRepository;
        this.userManager = userManager;
    }

    public async Task<User> CreateAsync(CreateRequestDto createRequest)
    {
        if(createRequest is CreateUserRequestDto dto)
        {
            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
            };
        

            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new BadRequestException(string.Join(", "
                , result.Errors.Select(e => e.Description)));
            }

        }

         throw new ArgumentException("Invalid DTO type for User update");
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new NotFoundException($"User with id {id} not found.");
        }

        return await userRepository.DeleteAsync(id);
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

    public async Task<User> GetUserWithTasksAndCategoriesAsync(Guid id)
    {
        var user = await userRepository.FindWithTasksAndCategoriesAsync(id);

        if (user == null)
        {
            throw new NotFoundException($"User with id {id} not found.");
        }

        return user;
    }

    public async Task<User> UpdateAsync(Guid id, UpdateRequestDto updateRequest)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new NotFoundException($"User with id {id} not found.");
        }

        if(updateRequest is UpdateUserRequestDto dto)
        {
            user.UserName = dto.UserName;

            return await this.userRepository.UpdateAsync(user);
        }

        throw new ArgumentException("Invalid DTO type for User update");
    }
}
