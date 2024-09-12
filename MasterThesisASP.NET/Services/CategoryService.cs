using System;
using MasterThesisASP.NET.Dtos.Abstract;
using MasterThesisASP.NET.Dtos.Categories;
using MasterThesisASP.NET.Exceptions;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Repositories.Interfaces;
using MasterThesisASP.NET.Services.Interfaces;

namespace MasterThesisASP.NET.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }
    public async Task<Category> CreateAsync(CreateRequestDto categoryDto)
    {
        if(categoryDto is CreateCategoryRequestDto dto)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = dto.Name
            };

            return await categoryRepository.CreateAsync(category);
        }
        
        throw new ArgumentException("Invalid DTO type for Category create");
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        Category? category = await categoryRepository.GetByIdAsync(id);

        if(category is null)
        {
            throw new NotFoundException($"The category with id = {id} does not exist.");
        }

         return await categoryRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await categoryRepository.GetAllAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        Category? category  = await categoryRepository.GetByIdAsync(id);

        if(category is null)
        {
            throw new NotFoundException($"The category with id = {id} does not exist.");
        }

        return category;
    }

    public async Task<IEnumerable<CategoryWithTaskCountDto>> GetCategoriesWithTaskCountAsync()
    {
        return await categoryRepository.GetCategoriesWithTaskCountAsync();
    }

    public async Task<Category> UpdateAsync(Guid id, UpdateRequestDto categoryDto)
    {
        Category? category = await categoryRepository.GetByIdAsync(id);

        if(category is null)
        {
            throw new NotFoundException($"The category with id = {id} does not exist.");
        }

        if(categoryDto is UpdateCategoryRequestDto dto)
        {
            category.Name = dto.Name;

            return await categoryRepository.UpdateAsync(category);
        }
        
        throw new ArgumentException("Invalid DTO type for Category update");
    }
}
