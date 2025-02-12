namespace QFXTaskMan.Core.Models;

public sealed class Organization : BaseClass
{
    public Organization()
    {
        
    }

    public Organization(string name, string description, Guid ownerId)
    {
        Name = name;
        Description = description;
        OwnerId = ownerId;
    }

    public required string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Foreign keys
    public required Guid OwnerId { get; set; }

    // Navigation properties
    public required User Owner { get; set; }

    public ICollection<OrganizationUser>? OrganizationUsers { get; set; }

    public ICollection<Project>? Projects { get; set; }
} 