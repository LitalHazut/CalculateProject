using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using IO.Swagger.Services;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// Controller responsible for authentication-related actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">Service used for authenticating users.</param>
        public AuthController(AuthenticationService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token if credentials are valid.
        /// </summary>
        /// <param name="user">The user's login credentials.</param>
        /// <returns>JWT token if authentication is successful; otherwise, 401 Unauthorized.</returns>
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
}
