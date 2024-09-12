using System;
using System.ComponentModel.DataAnnotations;
using MasterThesisASP.NET.Dtos.Abstract;

namespace MasterThesisASP.NET.Dtos.Categories;

public class CreateCategoryRequestDto : CreateRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
    public string Name { get; set; }
}
