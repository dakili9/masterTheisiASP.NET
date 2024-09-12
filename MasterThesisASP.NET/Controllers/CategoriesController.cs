using MasterThesisASP.NET.Dtos.Categories;
using MasterThesisASP.NET.Mappings;
using MasterThesisASP.NET.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterThesisASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

    [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetAllAsync();

            var categoryDtos = categories.Select(s => s.ToCategoryDto()).ToList();

            return Ok(categoryDtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var category = await categoryService.GetByIdAsync(id);
            
            return Ok(category?.ToCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto dto)
        {
            var category = await categoryService.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category.ToCategoryDto());
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto dto)
        {
            var updatedCategory = await categoryService.UpdateAsync(id, dto);

            return Ok(updatedCategory.ToCategoryDto());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await categoryService.DeleteAsync(id);
            
            return Ok(new { success = deleted });
        }

        [HttpGet("with-task-count")]
        public async Task<IActionResult> GetCategoriesWithTaskCount()
        {
            var categories = await categoryService.GetCategoriesWithTaskCountAsync();

            return Ok(categories);
        }
    }
}
