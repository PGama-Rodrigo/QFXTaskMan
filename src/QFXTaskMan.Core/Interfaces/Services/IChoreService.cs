using QFXTaskMan.Core.Models.DTO;

namespace QFXTaskMan.Core.Interfaces.Services;

public interface IChoreService : IBaseService<ChoreDTO>
{
    Task<IEnumerable<ChoreDTO>> GetAllByProjectAsync(Guid projectId);
    Task<IEnumerable<ChoreDTO>> GetAllByUserAsync(Guid userId);
}