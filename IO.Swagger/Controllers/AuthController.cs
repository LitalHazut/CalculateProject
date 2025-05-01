using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using IO.Swagger.Services;



[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthenticationService _authService;

    public AuthController(AuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserModel user)
    {
        var token = _authService.Authenticate(user);
        if (token == null)
        {
            return Unauthorized("Invalid credentials");
        }

        return Ok(new { Token = token });
    }
}

