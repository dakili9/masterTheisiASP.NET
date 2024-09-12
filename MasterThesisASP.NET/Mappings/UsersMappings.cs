using System;
using MasterThesisASP.NET.Dtos.Tasks;
using MasterThesisASP.NET.Dtos.Users;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Repositories;

namespace MasterThesisASP.NET.Mappings;

public static class UsersMappings
{
    public static UserDto ToUserDto(this User userModel)
    {
        return new UserDto
        {
            Id = userModel.Id.ToString(),
            Username = userModel.UserName,
            Email = userModel.Email,
            IsAdmin = userModel.IsAdmin
        };
    }
}
