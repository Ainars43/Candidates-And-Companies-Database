using HeadhuntersCandidatesDatabase.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadhuntersCandidatesDatabase.Data;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Skill> Skill { get; set; }
    public DbSet<Position> Position { get; set; }
    public DbSet<CandidateSkillset> CandidateSkillset { get; set; }
    public DbSet<CompanyPositions> CompanyPositions { get; set; }
    public DbSet<PositionSkills> PositionSkills { get; set; }
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}