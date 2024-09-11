using System;
using Microsoft.AspNetCore.Identity;

namespace MasterThesisASP.NET.Models;

public class User : IdentityUser<Guid>
{
    public bool IsAdmin { get; set; } = false;
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}
