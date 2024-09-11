using System;
using MasterThesisASP.NET.Dtos.Abstract;
using MasterThesisASP.NET.Dtos.Categories;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Services.Interfaces;

namespace MasterThesisASP.NET.Services;

public class CategoryService : ICategoryService
{
    public Task<Category> CreateAsync(CreateRequestDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateAsync(Guid id, UpdateRequestDto entity)
    {
        throw new NotImplementedException();
    }
}
