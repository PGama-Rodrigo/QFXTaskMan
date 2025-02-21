namespace QFXTaskMan.Core.Interfaces.Repositories;

public interface ITaskRepository
{
    Task<Models.Task> GetByIdAsync(Guid id);
    Task<IEnumerable<Models.Task>> GetAllAsync();
    Task<Models.Task> CreateAsync(Models.Task task);
    System.Threading.Tasks.Task UpdateAsync(Models.Task task);
    System.Threading.Tasks.Task DeleteAsync(Guid id);
    Task<IEnumerable<Models.Task>> GetByProjectAsync(Guid projectId);
    Task<IEnumerable<Models.Task>> GetByUserAsync(Guid userId);
}