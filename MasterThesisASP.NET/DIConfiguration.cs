using System;
using MasterThesisASP.NET.Repositories;
using MasterThesisASP.NET.Repositories.Interfaces;
using MasterThesisASP.NET.Services;
using MasterThesisASP.NET.Services.Interfaces;

namespace MasterThesisASP.NET;

public static class DIConfiguration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        return services.AddRepositories().AddServices();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddTransient<ITaskRepository, TaskRepository>()
        .AddTransient<ICategoryRepository, CategoryRepository>()
        .AddTransient<IUserRepository, UserRepository>();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddTransient<ITaskService, TaskService>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<IUserService, UserService>();
    }
}
