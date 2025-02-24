using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IProjectRepository : IRepository<Project>
{
    Task<IEnumerable<Project>> GetByOrganizationAsync(Guid organizationId);
}