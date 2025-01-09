using CandidateManagementSystem.Models.Authentication;
using CandidateManagementSystem.Services;

namespace CandidateManagementSystem.Clients;

public class AuthenticationClient : IAuthenticationClient
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationClient(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    public async Task<string> AuthenticateAsync(LoginModel loginModel)
    {
        if (loginModel == null || string.IsNullOrEmpty(loginModel.UserName) || string.IsNullOrEmpty(loginModel.Password))
            return null;
        
        if (loginModel.UserName == "admin" && loginModel.Password == "P@ssword")
        {
            var token = await _authenticationService.GenerateJwtToken(Guid.NewGuid(), "admin", "Administrator");
            return token;
        }

        return null;
    }
}