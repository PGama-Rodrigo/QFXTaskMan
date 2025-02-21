using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IOrganizationRepository
{
    Task<Organization> GetByIdAsync(Guid id);
    Task<IEnumerable<Organization>> GetAllAsync();
    Task<Organization> CreateAsync(Organization organization);
    System.Threading.Tasks.Task UpdateAsync(Organization organization);
    System.Threading.Tasks.Task DeleteAsync(Guid id);
    Task<IEnumerable<Organization>> GetByUserAsync(Guid userId);
}