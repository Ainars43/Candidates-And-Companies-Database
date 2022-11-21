using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;

namespace HeadhuntersCandidatesDatabase.Services;

public class PositionService : EntityService<Position>, IPositionService
{
    public PositionService(IDatabaseContext context) : base(context)
    {
    }
}