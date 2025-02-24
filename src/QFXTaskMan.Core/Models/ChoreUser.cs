using QFXTaskMan.Core.Enumerables;

namespace QFXTaskMan.Core.Models;

public sealed class ChoreUser
{
    public Guid ChoreId { get; set; }

    public Guid UserId { get; set; }

    public ETaskUserLevel Level { get; set; } = ETaskUserLevel.Member;

    public required Chore Chore { get; set; }

    public required User User { get; set; }
}