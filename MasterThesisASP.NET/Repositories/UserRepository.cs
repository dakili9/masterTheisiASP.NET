using System;
using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterThesisASP.NET.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<User?> FindWithTasksAndCategoriesAsync(Guid userId)
    {
         return await context.Users
            .Include(u => u.Tasks)
            .ThenInclude(t => t.Category)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<IEnumerable<User>> GetUsersWithTasksAsync()
    {
        return await context.Users
            .Include(u => u.Tasks)
            .ToListAsync();
    }
}
