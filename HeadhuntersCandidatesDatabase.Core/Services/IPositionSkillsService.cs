using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services;

public interface IPositionSkillsService : IEntityService<PositionSkills>
{
    PositionSkills FindPosition(Position position);
}