using System;

namespace MasterThesisASP.NET.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public Task<T> CreateAsync(T entity);
    public  Task<bool> DeleteAsync(Guid id);
    public Task<bool> ExistsAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(Guid id);
    public Task<T> UpdateAsync(T entity);
}
