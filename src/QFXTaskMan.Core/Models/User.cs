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

    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public required string Username { get; set; } = "";
    public required string PasswordHash { get; set; } = "";
    public List<string> Roles { get; set; } = [];

    public ICollection<Project>? OwnedProjects { get; set; }
    public ICollection<TaskUser>? AssignedTasks { get; set; }
    public required ICollection<OrganizationUser> Organizations { get; set; }
}