using System;
using System.ComponentModel.DataAnnotations;

namespace MasterThesisASP.NET.Dtos.Abstract;

public abstract class UpdateRequestDto
{
    [Required]
    public string UserName { get; set; }
}
