using CandidateManagementSystem.Clients;
using CandidateManagementSystem.Data;
using CandidateManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class CandidateClient : ICandidateClient
{
    private readonly CandidateDbContext _context;

    public CandidateClient(CandidateDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CandidateModel>> GetCandidatesAsync()
    {
        return await _context.Candidates.OrderBy(o => o.DateCreated).OrderDescending().ToListAsync();
    }

    public async Task<CandidateModel> GetCandidateByIdAsync(Guid id)
    {
        return await _context.Candidates.FindAsync(id);
    }

    public async Task AddCandidateAsync(CandidateModel candidate)
    {
        candidate.DateCreated = DateTime.UtcNow;
        _context.Candidates.Add(candidate);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCandidateAsync(CandidateModel candidate)
    {
        _context.Entry(candidate).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCandidateByIdAsync(Guid id)
    {
        var candidate = await _context.Candidates.FindAsync(id);
        if (candidate != null)
        {
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
        }
    }
}