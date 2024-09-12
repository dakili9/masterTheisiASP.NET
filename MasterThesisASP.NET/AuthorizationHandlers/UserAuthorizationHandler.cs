using System;
using System.Security.Claims;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Task = System.Threading.Tasks.Task;

namespace MasterThesisASP.NET.AuthorizationHandlers;

public class UserAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, User>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OperationAuthorizationRequirement requirement,
        User targetUser)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var isAdmin = context.User.HasClaim(c => c.Type == "IsAdmin" && c.Value == "True");

        if (requirement.Name == nameof(UserOperations.CreateUser))
        {
            if (isAdmin)
            {
                context.Succeed(requirement);
            }
        }
        else if (requirement.Name == nameof(UserOperations.UpdateUser))
        {
            if (isAdmin || userId == targetUser.Id.ToString())
            {
                context.Succeed(requirement);
            }
        }
        else if (requirement.Name == nameof(UserOperations.DeleteUser))
        {
            if (isAdmin && userId != targetUser.Id.ToString())
            {
                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }
}
