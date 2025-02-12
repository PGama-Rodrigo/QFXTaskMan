namespace QFXTaskMan.Core.Models;

public class OrganizationUser
{
    public Guid OrganizationId { get; set; }

    public Guid UserId { get; set; }

    public required Organization Organization { get; set; }

    public required User User { get; set; }
}