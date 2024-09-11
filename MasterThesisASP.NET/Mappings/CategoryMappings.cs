using MasterThesisASP.NET.Dtos.Categories;
using MasterThesisASP.NET.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MasterThesisASP.NET.Mappings;

public static class CategoryMappings
{
    public static CategoryDto ToCategoryDto(this Category categoryModel)
    {
        return new CategoryDto
        {
            Id = categoryModel.Id.ToString(),
            Name = categoryModel.Name
        };
    }
}
