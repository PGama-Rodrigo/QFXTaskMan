using System.ComponentModel.DataAnnotations;

namespace QFXTaskMan.Core.Models;

public sealed class User : BaseClass
{
    public User()
    {

    }

    public User(string name, string email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
    }

    [Required(ErrorMessage = "{0} is required"), MaxLength(100, ErrorMessage = "{0} cannot be longer than 100 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "{0} is required"), MaxLength(256, ErrorMessage = "{0} cannot be longer than 256 characters")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "{0} is required"), MinLength(8, ErrorMessage = "{0} must be at least 8 characters long"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "{0} must contain at least one uppercase letter, one lowercase letter, and one number")]
    public string PasswordHash { get; set; } = string.Empty;

    public ICollection<Project>? OwnedProjects { get; set; }
    public ICollection<ChoreUser>? AssignedChores { get; set; }
    public ICollection<OrganizationUser> Organizations { get; set; }
}