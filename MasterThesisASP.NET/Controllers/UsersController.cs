using MasterThesisASP.NET.Dtos.Users;
using MasterThesisASP.NET.Mappings;
using MasterThesisASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterThesisASP.NET.Data.config
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await userService.GetAllAsync();
            
            return Ok(users.Select(u => u.ToUserDto()).ToList());
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var user = await userService.GetByIdAsync(id);

            return Ok(user?.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto dto)
        {
            var createdUser = await userService.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequestDto dto)
        {
            var updatedUser = await userService.UpdateAsync(id, dto);

            return Ok(updatedUser.ToUserDto());
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await userService.DeleteAsync(id);

            return Ok(new { success = deleted });
        }
    }
}
