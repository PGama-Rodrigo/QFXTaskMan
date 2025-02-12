using Microsoft.AspNetCore.Mvc;
using QFXTaskMan.Core.Interfaces;
using QFXTaskMan.Core.Models;

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
    public ActionResult<User> Register([FromBody] RegisterDto model)
    {
        var user = new User 
        {
            Name = model.Name,
            Username = model.Username,
            Email = model.Email,
            PasswordHash = model.Password
        };

        var result = _authService.Register(user, model.Password);
        return Ok(result);
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginDto model)
    {
        var token = _authService.Authenticate(model.Username, model.Password);
        
        if (token == null)
            return Unauthorized();

        return Ok(new { token });
    }
}