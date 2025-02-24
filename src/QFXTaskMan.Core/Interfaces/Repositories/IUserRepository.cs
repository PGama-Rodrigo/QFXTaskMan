using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<User>> GetByOrganizationAsync(Guid organizationId);
    Task<IEnumerable<User>> GetByTaskAsync(Guid taskId);
}
