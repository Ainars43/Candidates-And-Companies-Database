using HeadhuntersCandidatesDatabase.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HeadhuntersCandidatesDatabase.Data;

public interface IDatabaseContext
{
    DbSet<Candidate> Candidates { get; set; }
    DbSet<Company> Companies { get; set; }
    DbSet<Skill> Skill { get; set; }
    DbSet<Position> Position { get; set; }
    DbSet<T> Set<T>() where T : class;
    DbSet<CandidateSkillset> CandidateSkillset { get; set; }
    DbSet<CompanyPositions> CompanyPositions { get; set; }
    DbSet<PositionSkills> PositionSkills { get; set; }
    EntityEntry<T> Entry<T>(T entity) where T : class;
    int SaveChanges();
    Task<int> SaveChangesAsync();
}