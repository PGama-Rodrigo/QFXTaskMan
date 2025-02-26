using System.ComponentModel.DataAnnotations;

namespace QFXTaskMan.Core.Models.DTO;

public abstract class BaseUserDTO : BaseDTO
{
    [Required(ErrorMessage = "{0} is required"), MaxLength(256, ErrorMessage = "{0} cannot be longer than 256 characters")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required"), MaxLength(100, ErrorMessage = "{0} cannot be longer than 100 characters")]
    public string Name { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    public string? ProfilePictureUrl { get; set; }

    public List<AddressDTO> Addresses { get; set; } = [];
}

public sealed class UserDTO : BaseUserDTO
{
    ICollection<LogDTO> Logs { get; set; } = [];
}

public sealed class CreateUserDTO : BaseUserDTO
{
    [Required(ErrorMessage = "{0} is required"), MinLength(8, ErrorMessage = "{0} must be at least 8 characters long"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "{0} must contain at least one uppercase letter, one lowercase letter, and one number")]
    public string Password { get; set; } = string.Empty;
}

public sealed class UpdateUserDTO : BaseUserDTO
{

}

public sealed class ListUserDTO : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}

public sealed class LoginDTO
{
    [Required(ErrorMessage = "{0} is required"), MaxLength(256, ErrorMessage = "{0} cannot be longer than 256 characters")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required"), MinLength(8, ErrorMessage = "{0} must be at least 8 characters long"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "{0} must contain at least one uppercase letter, one lowercase letter, and one number")]
    public string Password { get; set; } = string.Empty;
}

public sealed class AddressDTO : BaseDTO
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

public sealed class LogDTO
{
    public string Who { get; set; } = string.Empty;
    public string What { get; set; } = string.Empty;
    public DateTime When { get; set; }
    public string DifferenceBeforeAfter { get; set; } = string.Empty;
}