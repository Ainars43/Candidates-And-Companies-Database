using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Core.Models;

public class PositionSkills : Entity
{
    public Position Position { get; set; }
    public Skill? SkillList { get; set; }
}