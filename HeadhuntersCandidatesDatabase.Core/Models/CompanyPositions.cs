using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Core.Models;

public class CompanyPositions : Entity
{
    public Company Company { get; set; }
    public Position? Positions { get; set; }
}