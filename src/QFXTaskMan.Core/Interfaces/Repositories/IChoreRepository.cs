using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IChoreRepository : IRepository<Chore>
{
    Task<IEnumerable<Chore>> GetByProjectAsync(Guid projectId);
    Task<IEnumerable<Chore>> GetByUserAsync(Guid userId);
}