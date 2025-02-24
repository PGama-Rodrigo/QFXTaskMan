namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface IChoreRepository : IRepository<Models.Chore>
{
    Task<IEnumerable<Models.Chore>> GetByProjectAsync(Guid projectId);
    Task<IEnumerable<Models.Chore>> GetByUserAsync(Guid userId);
}