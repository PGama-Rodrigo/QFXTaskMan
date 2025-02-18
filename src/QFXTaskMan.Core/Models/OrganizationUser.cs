using QFXTaskMan.Core.Enumerables;

namespace QFXTaskMan.Core.Models;

public sealed class OrganizationUser
{
    public Guid OrganizationId { get; set; }

    public Guid UserId { get; set; }

    public EOrganizationUserLevel Level { get; set; } = EOrganizationUserLevel.Mid;

    public required Organization Organization { get; set; }

    public required User User { get; set; }
}