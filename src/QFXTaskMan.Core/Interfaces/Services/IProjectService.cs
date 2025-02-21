namespace QFXTaskMan.Core.Interfaces.Services;

public interface IProjectService
{
    Task<ProjectDto> GetByIdAsync(Guid id);
    Task<IEnumerable<ProjectDto>> GetAllAsync();
    Task<ProjectDto> CreateAsync(CreateProjectDto projectDto);
    Task UpdateAsync(Guid id, UpdateProjectDto projectDto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<ProjectDto>> GetByOrganizationAsync(Guid organizationId);
}