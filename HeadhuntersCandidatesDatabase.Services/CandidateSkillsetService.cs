using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;

namespace HeadhuntersCandidatesDatabase.Services;

public class CandidateSkillsetService : EntityService<CandidateSkillset>, ICandidateSkillsetService
{
    public CandidateSkillsetService(IDatabaseContext context) : base(context)
    {
    }
}