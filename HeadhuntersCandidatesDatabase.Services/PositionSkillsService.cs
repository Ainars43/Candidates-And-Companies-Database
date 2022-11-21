using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;

namespace HeadhuntersCandidatesDatabase.Services;

public class PositionSkillsService : EntityService<PositionSkills>, IPositionSkillsService
{
    public PositionSkillsService(IDatabaseContext context) : base(context)
    {
    }

    public PositionSkills FindPosition(Position position)
    {
        var result = _context.PositionSkills.SingleOrDefault(p => p.Position.Name == position.Name);

        return result;
    }
}