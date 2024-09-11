using System;
using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Repositories.Interfaces;

namespace MasterThesisASP.NET.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
