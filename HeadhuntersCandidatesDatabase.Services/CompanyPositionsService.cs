using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;

namespace HeadhuntersCandidatesDatabase.Services;

public class CompanyPositionsService : EntityService<CompanyPositions>, ICompanyPositionsService
{
    public CompanyPositionsService(IDatabaseContext context) : base(context)
    {
    }
}