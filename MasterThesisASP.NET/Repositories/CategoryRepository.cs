using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.Dtos.Categories;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterThesisASP.NET.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CategoryWithTaskCountDto>> GetCategoriesWithTaskCountAsync()
    {
        return await context.Categories
        .Select(c => new CategoryWithTaskCountDto
        {
            Id = c.Id,
            Name = c.Name,
            TaskCount = c.Tasks.Count()
        })
        .ToListAsync();
    }
}
