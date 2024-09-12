using System;
using System.Security.Claims;
using MasterThesisASP.NET.Models;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace MasterThesisASP.NET.IdentityEnhancemets;

public class AppClaimsFactory : IUserClaimsPrincipalFactory<User>
{
    public Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim("IsAdmin", user.IsAdmin.ToString())
        };
        
        var claimsIdentity = new ClaimsIdentity(claims, "Bearer");
        return Task.FromResult(new ClaimsPrincipal(claimsIdentity));
    }
}
