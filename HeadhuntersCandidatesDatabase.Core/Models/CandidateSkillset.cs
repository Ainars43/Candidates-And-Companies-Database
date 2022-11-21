using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Core.Models;

public class CandidateSkillset : Entity
{
    public Candidate Candidate { get; set; }
    public Skill? SkillList { get; set; }
}