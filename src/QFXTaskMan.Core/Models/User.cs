using System.ComponentModel.DataAnnotations;

namespace QFXTaskMan.Core.Models;

public sealed class User : BaseClass
{
    public User()
    {

    }

    public User(string name, string email, string username, string passwordHash)
    {
        Name = name;
        Email = email;
        Username = username;
        PasswordHash = passwordHash;
    }

    [Required(ErrorMessage = "{0} is required"), MaxLength(100, ErrorMessage = "{0} cannot be longer than 100 characters")]
    public string Name { get; set; } = "";
    
    [Required(ErrorMessage = "{0} is required"), MaxLength(256, ErrorMessage = "{0} cannot be longer than 256 characters")]
    public string Email { get; set; } = "";
    
    [Required(ErrorMessage = "{0} is required"), MaxLength(100, ErrorMessage = "{0} cannot be longer than 100 characters")]
    public string Username { get; set; } = "";
    
    [Required(ErrorMessage = "{0} is required"), MinLength(8, ErrorMessage = "{0} must be at least 8 characters long"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "{0} must contain at least one uppercase letter, one lowercase letter, and one number")]
    public string PasswordHash { get; set; } = "";
    public List<string> Roles { get; set; } = [];

    public ICollection<Project>? OwnedProjects { get; set; }
    public ICollection<TaskUser>? AssignedTasks { get; set; }
    public required ICollection<OrganizationUser> Organizations { get; set; }
}