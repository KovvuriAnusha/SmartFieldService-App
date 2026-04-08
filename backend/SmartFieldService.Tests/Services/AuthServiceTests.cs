using SmartFieldService.Application.DTOs;
using SmartFieldService.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldService.Tests.Services
{
  
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        public AuthServiceTests()
        {
            _authService = new AuthService();
        }
        [Fact]
        public async Task Login_WithValidCredentials_ReturnsToken()
        {
            var request = new LoginRequestDto
            {
                Email = "test@test.com",
                Password = "123456"
            };

            var result = await _authService.LoginAsync(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Token);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ReturnsNull()
        {
            var request = new LoginRequestDto
            {
                Email = "wrong@test.com",
                Password = "wrong"
            };

            var result = await _authService.LoginAsync(request);

            Assert.Null(result);
        }
    }
}
