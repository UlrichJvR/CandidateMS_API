using CandidateManagementSystem.Models;

namespace CandidateManagementSystem.Clients;

public interface ICandidateClient
{
    public Task<IEnumerable<CandidateModel>> GetCandidatesAsync();

    public Task<CandidateModel> GetCandidateByIdAsync(Guid id);

    public Task AddCandidateAsync(CandidateModel candidate);

    public Task UpdateCandidateAsync(CandidateModel candidate);

    public Task DeleteCandidateByIdAsync(Guid id);
}