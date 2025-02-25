using System.ComponentModel.DataAnnotations;

namespace QFXTaskMan.Core.Models;

public sealed class Organization : BaseModel
{
    public Organization()
    {
        
    }

    public Organization(string name, string description)
    {
        Name = name;
        Description = description;
    }

    [Required(ErrorMessage = "{0} is required"), MaxLength(100, ErrorMessage = "{0} cannot be longer than 100 characters")]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation properties
    public required User Owner { get; set; }

    public ICollection<OrganizationUser>? OrganizationUsers { get; set; }

    public ICollection<Project>? Projects { get; set; }
} 