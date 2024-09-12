using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MasterThesisASP.NET.Operations;

public static class UserOperations
{
    public static OperationAuthorizationRequirement CreateUser = 
        new OperationAuthorizationRequirement { Name = nameof(CreateUser) };

    public static OperationAuthorizationRequirement UpdateUser = 
        new OperationAuthorizationRequirement { Name = nameof(UpdateUser) };

    public static OperationAuthorizationRequirement DeleteUser = 
        new OperationAuthorizationRequirement { Name = nameof(DeleteUser) };
}
