using System;
using MasterThesisASP.NET.Dtos.Categories;
using MasterThesisASP.NET.Models;

namespace MasterThesisASP.NET.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    public Task<IEnumerable<CategoryWithTaskCountDto>> GetCategoriesWithTaskCountAsync();
}
