using System;
using MasterThesisASP.NET.Dtos.Abstract;

namespace MasterThesisASP.NET.Services.Interfaces;

public interface IBaseService<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(Guid id);
    public Task<T> CreateAsync(CreateRequestDto entity);
    public Task<T> UpdateAsync(Guid id, UpdateRequestDto entity);
    public Task<bool> DeleteAsync(Guid id);
}