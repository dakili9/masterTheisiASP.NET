using System;
using MasterThesisASP.NET.ExceptionHandlers;

namespace MasterThesisASP.NET;

public static class ExceptionHandling
{
    public static IServiceCollection AddExceptionHandlers(this IServiceCollection services)
    {
        return services
            .AddExceptionHandler<BadRequestExceptionHandler>()
            .AddExceptionHandler<NotFoundExceptionHandler>()
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails();
    }
}
