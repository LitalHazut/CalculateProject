using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace IO.Swagger.Services
{
    /// <summary>
    /// Provides authentication services, including JWT token generation.
    /// </summary>
    public class AuthenticationService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="configuration">Application configuration used to access JWT settings.</param>
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates the specified user and returns a JWT token if successful.
        /// </summary>
        /// <param name="user">The user credentials.</param>
        /// <returns>A JWT token string if authentication is successful; otherwise, <c>null</c>.</returns>
        public string Authenticate(UserModel user)
        {
            if (user.Username == "admin" && user.Password == "password")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null;
        }
    }
}