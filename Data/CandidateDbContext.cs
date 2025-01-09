using Microsoft.EntityFrameworkCore;
using CandidateManagementSystem.Models;

namespace CandidateManagementSystem.Data;

public class CandidateDbContext : DbContext
{
    public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }

    public DbSet<CandidateModel> Candidates { get; set; }
}