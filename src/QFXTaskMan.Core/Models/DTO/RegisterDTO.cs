using System.ComponentModel.DataAnnotations;

namespace QFXTaskMan.Core.Models;

public sealed class RegisterDto
{
    public required string Name { get; set; }    
    public required string Username { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [MinLength(6)]
    public required string Password { get; set; }
}