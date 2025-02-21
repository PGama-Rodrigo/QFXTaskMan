using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    System.Threading.Tasks.Task UpdateAsync(User user);
    System.Threading.Tasks.Task DeleteAsync(Guid id);
    Task<IEnumerable<User>> GetByOrganizationAsync(Guid organizationId);
    Task<IEnumerable<User>> GetByTaskAsync(Guid taskId);
}