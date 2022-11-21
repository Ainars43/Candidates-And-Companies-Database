using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services;

public interface ICandidateService : IEntityService<Candidate>
{
    Candidate UpdateCandidateById(int id, Candidate candidate);
    CandidateSkillset AddSkill(int candidateId, Skill skill);
    CandidateSkillset FindSkillset(int candidateId, Skill skill);
    List<Candidate> GetCandidatesList(Skill skill);
}