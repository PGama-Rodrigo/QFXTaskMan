using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IProjectRepository
{
    Task<Project> GetByIdAsync(Guid id);
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project> CreateAsync(Project project);
    System.Threading.Tasks.Task UpdateAsync(Project project);
    System.Threading.Tasks.Task DeleteAsync(Guid id);
    Task<IEnumerable<Project>> GetByOrganizationAsync(Guid organizationId);
}