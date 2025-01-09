namespace CandidateManagementSystem.Services;

public interface IAuthenticationService
{
    Task<string> GenerateJwtToken(Guid userId, string userName, string role);
}