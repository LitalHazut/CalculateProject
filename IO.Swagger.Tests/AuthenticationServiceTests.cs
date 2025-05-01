using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using IO.Swagger.Services;

namespace IO.Swagger.Tests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private AuthenticationService _authService;
        
        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:SecretKey", "XyZ!9f#7LpQ2rT4uGh6jKmN8sVbY1wXa"},
                {"Jwt:Issuer", "MyApiIssuer"},
                {"Jwt:Audience", "MyApiAudience"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _authService = new AuthenticationService(configuration);
        }

        /// <summary>
        /// Tests that valid credentials return a non-null and non-empty token.
        /// </summary>
        [Test]
        public void Authenticate_ValidCredentials_ReturnsToken()
        {
            var user = new UserModel { Username = "admin", Password = "password" };
            var token = _authService.Authenticate(user);
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);
        }


        /// <summary>
        /// Tests that invalid credentials return null.
        /// </summary>
        [Test]
        public void Authenticate_InvalidCredentials_ReturnsNull()
        {
            var user = new UserModel { Username = "user", Password = "wrongpassword" };
            var token = _authService.Authenticate(user);
            Assert.IsNull(token);
        }
    }
}
