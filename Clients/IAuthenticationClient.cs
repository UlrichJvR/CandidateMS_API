using CandidateManagementSystem.Models.Authentication;

namespace CandidateManagementSystem.Clients;

public interface IAuthenticationClient
{
    Task<string> AuthenticateAsync(LoginModel loginModel);
}