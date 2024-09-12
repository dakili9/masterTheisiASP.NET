using System;

namespace MasterThesisASP.NET.Dtos.Users;

public class UserDto
{
    public string Id { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsAdmin { get; set; }
}
