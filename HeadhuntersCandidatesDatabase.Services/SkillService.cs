using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;

namespace HeadhuntersCandidatesDatabase.Services;

public class SkillService : EntityService<Skill>, ISkillService
{
    public SkillService(IDatabaseContext context) : base(context)
    {
    }
}