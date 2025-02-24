using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    System.Threading.Tasks.Task UpdateAsync(T entity);
    System.Threading.Tasks.Task DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}