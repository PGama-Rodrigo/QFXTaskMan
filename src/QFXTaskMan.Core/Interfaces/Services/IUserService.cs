namespace QFXTaskMan.Core.Interfaces.Services;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(Guid id);
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto> CreateAsync(CreateUserDto userDto);
    Task UpdateAsync(Guid id, UpdateUserDto userDto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<UserDto>> GetByOrganizationAsync(Guid organizationId);
    Task<IEnumerable<UserDto>> GetByTaskAsync(Guid taskId);
}
