using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services;

public interface ICompanyService : IEntityService<Company>
{
    Company UpdateCompanyById(int id, Company company);
    CompanyPositions AddPosition(int companyId, Position position);
    CompanyPositions FindPosition(int companyId, Position position);
    List<Position> GetCompanyPositionsList(Company company);
    List<Company> GetCompaniesList(Position position);
    List<Company> GetCompaniesList(Skill skill);
}