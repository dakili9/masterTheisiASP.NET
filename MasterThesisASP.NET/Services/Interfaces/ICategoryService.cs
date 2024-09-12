using MasterThesisASP.NET.Dtos.Categories;
using MasterThesisASP.NET.Models;

namespace MasterThesisASP.NET.Services.Interfaces;

public interface ICategoryService : IBaseService<Category>
{
    public Task<IEnumerable<CategoryWithTaskCountDto>> GetCategoriesWithTaskCountAsync();
}
