using System;
using System.ComponentModel.DataAnnotations;
using MasterThesisASP.NET.Dtos.Abstract;

namespace MasterThesisASP.NET.Dtos.Users;

public class CreateUserRequestDto : CreateRequestDto
{
    [Required]
    public string UserName {get; set;}

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password {get; set;}
}
