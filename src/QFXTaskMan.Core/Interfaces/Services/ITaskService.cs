namespace QFXTaskMan.Core.Interfaces.Services;

public interface ITaskService
{
    Task<TaskDto> GetByIdAsync(Guid id);
    Task<IEnumerable<TaskDto>> GetAllAsync();
    Task<TaskDto> CreateAsync(CreateTaskDto taskDto);
    Task UpdateAsync(Guid id, UpdateTaskDto taskDto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<TaskDto>> GetByProjectAsync(Guid projectId);
    Task<IEnumerable<TaskDto>> GetByUserAsync(Guid userId);
}