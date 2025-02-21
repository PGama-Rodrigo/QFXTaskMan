namespace QFXTaskMan.Core.Interfaces.Services;

public interface IOrganizationService
{
    Task<OrganizationDto> GetByIdAsync(Guid id);
    Task<IEnumerable<OrganizationDto>> GetAllAsync();
    Task<OrganizationDto> CreateAsync(CreateOrganizationDto organizationDto);
    Task UpdateAsync(Guid id, UpdateOrganizationDto organizationDto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<OrganizationDto>> GetByUserAsync(Guid userId);
}