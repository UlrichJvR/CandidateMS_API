using CandidateManagementSystem.Clients;
using CandidateManagementSystem.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagementSystem.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationClient _authenticationClient;
        
        public AuthController(IAuthenticationClient authenticationClient, ILogger<AuthController> logger)
        {
            _authenticationClient = authenticationClient;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var token = await _authenticationClient.AuthenticateAsync(loginModel);

            if (token == null)
                return Unauthorized("Invalid username or password.");

            return Ok(new { token });
        }
    }
}