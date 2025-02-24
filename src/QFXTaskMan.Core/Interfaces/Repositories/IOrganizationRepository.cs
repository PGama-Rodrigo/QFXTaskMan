using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IOrganizationRepository : IRepository<Organization>
{
    Task<IEnumerable<Organization>> GetByUserAsync(Guid userId);
}