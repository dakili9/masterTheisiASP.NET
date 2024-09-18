using MasterThesisASP.NET.Enums;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Services;
using MasterThesisASP.NET.Services.Interfaces;
using MasterThesisASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MasterThesisASP.NET.Controllers
{
    [Route("/Users")]
    public class UsersMVCController : Controller
    {
        private readonly IUserService userService;

        public UsersMVCController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id:guid}/tasks")]
        public async Task<IActionResult> GetUserTasks([FromRoute] Guid id)
        {
            var user = await userService.GetUserWithTasksAndCategoriesAsync(id);

            var userTasksViewModel = ConvertToUserTasksDto(user);

            return View("UserTasks", userTasksViewModel);
        }

        private UserTasksViewModel ConvertToUserTasksDto(User user)
        {
            var tasks = user.Tasks.Select(t =>
             new TaskViewModel
                {
                    Name = t.Name,
                    Description = t.Description,
                    Status = t.Status is not null ? t.Status.GetStringValue() : "",
                    DueDate = t.DueDate,
                    CategoryName = t.Category?.Name
                }).ToList();

                return new UserTasksViewModel
                {
                    UserName = user?.UserName is not null ? user.UserName : "",
                    Tasks = tasks
                };
        }

    }
}
