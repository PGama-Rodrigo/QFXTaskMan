using Microsoft.AspNetCore.Mvc;
using QFXTaskMan.Core.Interfaces;
using QFXTaskMan.Core.Models;
using QFXTaskMan.Core.Models.DTO;

namespace QFXTaskMan.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public ActionResult<User> Register([FromBody] CreateUserDTO model)
    {
        
        var user = new User 
        {
            Name = model.Name,
            Email = model.Email,
            PasswordHash = model.Password,
            PhoneNumber = model.PhoneNumber,
            ProfilePictureUrl = model.ProfilePictureUrl
        };

        model.Addresses.ForEach(address => 
        {
            user.AddAddress(new Address
            {
                Street = address.Street,
                Number = address.Number,
                Complement = address.Complement,
                Reference = address.Reference,
                Neighborhood = address.Neighborhood,
                City = address.City,
                State = address.State
            });
        });

        var result = _authService.Register(user, model.Password);
        return Ok(result);
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginDTO model)
    {
        var token = _authService.Authenticate(model.Email, model.Password);
        
        if (token == null)
            return Unauthorized();

        return Ok(new { token });
    }
}