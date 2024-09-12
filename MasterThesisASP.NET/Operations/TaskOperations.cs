using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MasterThesisASP.NET.Operations;

public static class TaskOperations
{
    public static OperationAuthorizationRequirement CreateTask = 
        new OperationAuthorizationRequirement { Name = nameof(CreateTask) };

    public static OperationAuthorizationRequirement UpdateTask = 
        new OperationAuthorizationRequirement { Name = nameof(UpdateTask) };

    public static OperationAuthorizationRequirement DeleteTask = 
        new OperationAuthorizationRequirement { Name = nameof(DeleteTask) };
}
