namespace QFXTaskMan.Core.Interfaces.Services;

public interface IBaseService<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}