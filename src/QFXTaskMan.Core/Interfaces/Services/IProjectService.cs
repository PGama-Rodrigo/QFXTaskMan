using QFXTaskMan.Core.Models.DTO;

namespace QFXTaskMan.Core.Interfaces.Services;

public interface IProjectService : IBaseService<ProjectDTO>
{
    Task<IEnumerable<ProjectDTO>> GetAllByOrganizationAsync(Guid organizationId);
}