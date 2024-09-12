using System.Security.Claims;
using MasterThesisASP.NET.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

using MasterThesisASP.NET.Models;

namespace MasterThesisASP.NET.AuthorizationHandlers;

public class TaskAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Models.Task>
{
    protected override System.Threading.Tasks.Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OperationAuthorizationRequirement requirement,
        Models.Task task)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var isAdmin = context.User.HasClaim(c => c.Type == "IsAdmin" && c.Value == "True");

        if (requirement.Name == nameof(TaskOperations.CreateTask))
        {
            if (isAdmin)
            {
                context.Succeed(requirement);
            }
        }
        else if (requirement.Name == nameof(TaskOperations.UpdateTask))
        {
            if (isAdmin || userId == task.UserId.ToString())
            {
                context.Succeed(requirement);
            }
        }
        else if (requirement.Name == nameof(TaskOperations.DeleteTask))
        {
            if (isAdmin)
            {
                context.Succeed(requirement);
            }
        }

        return System.Threading.Tasks.Task.CompletedTask;
    }
}
