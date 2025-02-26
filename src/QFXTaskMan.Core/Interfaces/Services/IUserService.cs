using QFXTaskMan.Core.Models.DTO;

namespace QFXTaskMan.Core.Interfaces.Services;

public interface IUserService : IBaseService<UserDTO>
{
    Task<IEnumerable<UserDTO>> GetAllByOrganizationAsync(Guid organizationId);
    Task<IEnumerable<UserDTO>> GetAllByTaskAsync(Guid taskId);
}
