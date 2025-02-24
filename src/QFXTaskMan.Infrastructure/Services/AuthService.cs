using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QFXTaskMan.Core.Interfaces;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Services;

public sealed class AuthService : IAuthService 
{
    private readonly IConfiguration _configuration;
    // This is just for demo, in real app use proper user storage
    private readonly List<User> _users = new();

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Authenticate(string email, string password)
    {
        var user = _users.FirstOrDefault(x => x.Email == email);
        
        if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
            throw new Exception("Email or password is incorrect.");

        return GenerateJwtToken(user);
    }

    public User Register(User user, string password)
    {
        if (_users.Any(x => x.Email == user.Email))
            throw new Exception("Username already exists");

        user.PasswordHash = HashPassword(password);
        _users.Add(user);

        return user;
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is not configured")) ;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    // Simple password hashing (use a proper hashing library in production)
    private string HashPassword(string password)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPasswordHash(string password, string storedHash)
    {
        return storedHash == HashPassword(password);
    }
}