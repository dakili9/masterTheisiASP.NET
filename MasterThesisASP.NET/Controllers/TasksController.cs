using MasterThesisASP.NET.Dtos.Tasks;
using MasterThesisASP.NET.Helpers.QueryObjects;
using MasterThesisASP.NET.Mappings;
using MasterThesisASP.NET.Operations;
using MasterThesisASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterThesisASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IAuthorizationService authorizationService;

        public TasksController(
            ITaskService taskService,
            IAuthorizationService authorizationService)
        {
            this.taskService = taskService;
            this.authorizationService = authorizationService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await taskService.GetAllAsync();

            return Ok(tasks);
        }

        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var task = await taskService.GetByIdAsync(id);

            return Ok(task?.ToTaskDto());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskRequestDto taskDto)
        {
            var createdTask = await taskService.CreateAsync(taskDto);

            

            return CreatedAtAction(nameof(Get), new { id = createdTask.Id }, createdTask.ToTaskDto());
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTaskRequestDto taskDto)
        {
            var updatedTask = await taskService.UpdateAsync(id, taskDto);

            var authorizationResult = await authorizationService.
                AuthorizeAsync(User, updatedTask, TaskOperations.UpdateTask);

            if(!authorizationResult.Succeeded){{
                return Forbid();
            }}

            return Ok(updatedTask.ToTaskDto());
        }

        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await taskService.DeleteAsync(id);

            return Ok(new { success = deleted });
        }

        
        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] TaskQueryObject queryObject)
        {
            var tasks = await taskService.FilterAsync(queryObject);

            var taskDtos = tasks.Select(t => t.ToTaskDto()).ToList();

            return Ok(taskDtos);
        }
    }
}
