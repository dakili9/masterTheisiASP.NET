using MasterThesisASP.NET.Dtos.Tasks;
using MasterThesisASP.NET.Helpers.QueryObjects;
using MasterThesisASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterThesisASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await taskService.GetAllAsync();

            return Ok(tasks);
        }

        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var task = await taskService.GetByIdAsync(id);

            if (task is null)
            {
                return NotFound($"Task with {id} id is not found");
            }

            return Ok(task);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskRequestDto taskDto)
        {
            var createdTask = await taskService.CreateAsync(taskDto);

            return CreatedAtAction(nameof(Get), new { id = createdTask.Id }, createdTask);
        }

        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskRequestDto taskDto)
        {
            var updatedTask = await taskService.UpdateAsync(id, taskDto);

            if(updatedTask is null)
            {
                return NotFound($"Task with {id} id is not found");
            }

            return Ok(updatedTask);
        }

        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await taskService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound($"Task with {id} id is not found");
            }

            return Ok(new { success = true });
        }

        
        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] TaskQueryObject queryObject)
        {
            var tasks = await taskService.FilterAsync(queryObject);

            return Ok(tasks);
        }
    }
}
