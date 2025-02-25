using QFXTaskMan.Core.Models.DTO;

namespace QFXTaskMan.Core.Interfaces.Services;

public interface IChoreService : IBaseService<ChoreDTO>
{
    Task<IEnumerable<ChoreDTO>> GetByProjectAsync(Guid projectId);
    Task<IEnumerable<ChoreDTO>> GetByUserAsync(Guid userId);
}