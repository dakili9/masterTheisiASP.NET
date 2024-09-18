using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MasterThesisASP.NET.Operations;

public static class CategoryOperations
{
    public static OperationAuthorizationRequirement CreateCategory = 
        new OperationAuthorizationRequirement { Name = nameof(CreateCategory) };

    public static OperationAuthorizationRequirement UpdateCategory = 
        new OperationAuthorizationRequirement { Name = nameof(UpdateCategory) };

    public static OperationAuthorizationRequirement DeleteCategory = 
        new OperationAuthorizationRequirement { Name = nameof(DeleteCategory) };
}
