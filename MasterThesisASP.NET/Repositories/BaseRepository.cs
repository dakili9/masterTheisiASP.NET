using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterThesisASP.NET.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDbContext context;

    public BaseRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<T> CreateAsync(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity != null)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
         return await context.Set<T>()
         .AnyAsync(e => e.GetType().GetProperty("Id").GetValue(e)
         .Equals(id));
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();

        return entity;
    }

}
