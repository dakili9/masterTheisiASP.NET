using System;
using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Repositories.Interfaces;

namespace MasterThesisASP.NET.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
