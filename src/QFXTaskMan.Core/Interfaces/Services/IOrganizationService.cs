using QFXTaskMan.Core.Models.DTO;

namespace QFXTaskMan.Core.Interfaces.Services;

public interface IOrganizationService : IBaseService<OrganizationDTO>
{
    Task<IEnumerable<OrganizationDTO>> GetByUserAsync(Guid userId);
}