using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MasterThesisASP.NET.Operations;

public static class CategoryOperations
{
    public static OperationAuthorizationRequirement Create = 
        new OperationAuthorizationRequirement { Name = nameof(Create) };

    public static OperationAuthorizationRequirement Update = 
        new OperationAuthorizationRequirement { Name = nameof(Update) };

    public static OperationAuthorizationRequirement Delete = 
        new OperationAuthorizationRequirement { Name = nameof(Delete) };
}
