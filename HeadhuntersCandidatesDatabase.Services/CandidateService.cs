using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using HeadhuntersCandidatesDatabase.Services.Exceptions;

namespace HeadhuntersCandidatesDatabase.Services;

public class CandidateService : EntityService<Candidate>, ICandidateService
{
    public readonly IEntityService<Candidate> _entityService;
    public readonly ICandidateSkillsetService _candidateSkillsetService;
    public readonly ISkillService _skillService;

    public CandidateService(IDatabaseContext context, IEntityService<Candidate> entityService, ICandidateSkillsetService candidateSkillsetService, ISkillService skillService) : base(context)
    {
        _entityService = entityService;
        _candidateSkillsetService = candidateSkillsetService;
        _skillService = skillService;
    }

    public Candidate UpdateCandidateById(int id, Candidate candidate)
    {
        var candidateToUpdate = _entityService.GetByID(id);

        candidateToUpdate.Name = candidate.Name;

        _entityService.Update(candidateToUpdate);

        return candidateToUpdate;
    }

    public CandidateSkillset AddSkill(int candidateId, Skill skill)
    {
        var candidate = _entityService.GetByID(candidateId);

        if (_context.CandidateSkillset.Any(c => c.Candidate.Id == candidate.Id && c.SkillList == skill))
        {
            throw new DuplicateException();
        }

        var skillInDatabase = _context.Skill.FirstOrDefault(s => s.Name == skill.Name);

        if (skillInDatabase == null)
        {
            _skillService.Create(skill);
        }

        CandidateSkillset candidateSkill = new()
        {
            Candidate = candidate,
            SkillList = skill
        };

        _candidateSkillsetService.Create(candidateSkill);

        return candidateSkill;
    }

    public CandidateSkillset FindSkillset(int candidateId, Skill skill)
    {
        var skillset = _context.CandidateSkillset.SingleOrDefault(s => s.Candidate.Id == candidateId && s.SkillList.Name == skill.Name);

        return skillset;
    }

    public List<Candidate> GetCandidatesList(Skill skill)
    {
        var skillsetList = _context.CandidateSkillset.Where(s => s.SkillList.Name == skill.Name).ToList();

        var candidates = _context.Candidates.ToList();

        return (from skillset in skillsetList from candidate in candidates where candidate.Id == skillset.Candidate.Id select candidate).ToList();
    }
}