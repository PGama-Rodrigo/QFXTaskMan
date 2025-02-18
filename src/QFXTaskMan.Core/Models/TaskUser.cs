using QFXTaskMan.Core.Enumerables;

namespace QFXTaskMan.Core.Models;

public sealed class TaskUser
{
    public Guid TaskId { get; set; }

    public Guid UserId { get; set; }

    public ETaskUserLevel Level { get; set; } = ETaskUserLevel.Member;

    public required Task Task { get; set; }

    public required User User { get; set; }
}