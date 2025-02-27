using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace QFXTaskMan.Core.Models;

public sealed class User : BaseModel
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

    public string PhoneNumber { get; set; } = string.Empty;
    public string? ProfilePictureUrl { get; set; }

    #region Login
    [Required(ErrorMessage = "{0} is required"), MaxLength(256, ErrorMessage = "{0} cannot be longer than 256 characters")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required"), MinLength(8, ErrorMessage = "{0} must be at least 8 characters long"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "{0} must contain at least one uppercase letter, one lowercase letter, and one number")]
    public string PasswordHash { get; set; } = string.Empty;        
    #endregion

    public ICollection<ProjectUser>? AssignedProjects { get; set; }
    public ICollection<ChoreUser>? AssignedChores { get; set; }
    public ICollection<OrganizationUser>? Organizations { get; set; }

    string Addresses { get; set; } = string.Empty;  

    public List<Address> GetAddresses()
    {
        return string.IsNullOrEmpty(Addresses) ? 
            new List<Address>() : 
            JsonSerializer.Deserialize<List<Address>>(Addresses)!;
    }

    public void AddAddress(Address address)
    {
        var addresses = GetAddresses();
        addresses.Add(address);
        Addresses = JsonSerializer.Serialize(addresses);
    }
}

public sealed class Address : BaseModel
{
    public Guid UserId { get; set; }
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}