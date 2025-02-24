namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface ITaskRepository : IRepository<Models.Task>
{
    Task<IEnumerable<Models.Task>> GetByProjectAsync(Guid projectId);
    Task<IEnumerable<Models.Task>> GetByUserAsync(Guid userId);
}