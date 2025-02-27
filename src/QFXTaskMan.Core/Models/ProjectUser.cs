using QFXTaskMan.Core.Enumerables;

namespace QFXTaskMan.Core.Models;

public sealed class ProjectUser : BaseModel
{
    public Guid ProjectId { get; set; }

    public Guid UserId { get; set; }

    public ETaskUserLevel Level { get; set; } = ETaskUserLevel.Member;

    public required Project Project { get; set; }

    public required User User { get; set; }
}