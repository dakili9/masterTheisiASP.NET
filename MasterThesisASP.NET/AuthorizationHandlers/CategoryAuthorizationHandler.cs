using System;
using System.Security.Claims;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MasterThesisASP.NET.AuthorizationHandlers;

public class CategoryAuthorizationHandler: AuthorizationHandler<OperationAuthorizationRequirement, Category>
{
    protected override System.Threading.Tasks.Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OperationAuthorizationRequirement requirement,
        Category category)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var isAdmin = context.User.HasClaim(c => c.Type == "IsAdmin" && c.Value == "True");

        if (requirement.Name == nameof(CategoryOperations.Create))
        {
            if (isAdmin)
            {
                context.Succeed(requirement);
            }
        }
        else if (requirement.Name == nameof(CategoryOperations.Update))
        {
            if (isAdmin)
            {
                context.Succeed(requirement);
            }
        }
        else if (requirement.Name == nameof(CategoryOperations.Delete))
        {
            if (isAdmin)
            {
                context.Succeed(requirement);
            }
        }

        return System.Threading.Tasks.Task.CompletedTask;
    }
}
