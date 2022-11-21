using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Services;

public class CompanyService : EntityService<Company>, ICompanyService
{
    public readonly IEntityService<Company> _entityService;
    private readonly IDatabaseContext _context;
    private readonly IPositionService _positionService;
    private readonly ICompanyPositionsService _companyPositionsService;

    public CompanyService(IDatabaseContext context, IEntityService<Company> entityService, IPositionService positionService, ICompanyPositionsService companyPositionsService) : base(context)
    {
        _entityService = entityService;
        _context = context;
        _positionService = positionService;
        _companyPositionsService = companyPositionsService;
    }

    public Company UpdateCompanyById(int id, Company company)
    {
        var companyToUpdate = _entityService.GetByID(id);

        companyToUpdate.Name = company.Name;

        _entityService.Update(companyToUpdate);

        return companyToUpdate;
    }

    public CompanyPositions AddPosition(int companyId, Position position)
    {
        var company = _entityService.GetByID(companyId);

        var positionInDatabase = _context.Position.FirstOrDefault(p => p.Name == position.Name);

        if (positionInDatabase == null)
        {
            _positionService.Create(position);
        }

        CompanyPositions companyPositions = new()
        {
            Company = company,
            Positions = position
        };

        _companyPositionsService.Create(companyPositions);

        return companyPositions;
    }

    public CompanyPositions FindPosition(int companyId, Position position)
    {
        var companyPosition =
            _context.CompanyPositions.FirstOrDefault(
                p => p.Company.Id == companyId && p.Positions.Name == position.Name);

        return companyPosition;
    }

    public List<Position> GetCompanyPositionsList(Company company)
    {
        var positionList = _context.CompanyPositions.Where(p => p.Company.Id == company.Id).Select(s => s.Positions).ToList();

        return positionList;
    }

    public List<Company> GetCompaniesList(Position position)
    {
        var positionList = _context.CompanyPositions.Where(p => p.Positions.Name == position.Name).ToList();

        var companiesList = _context.Companies.ToList();

        return (from companyPosition in positionList from company in companiesList where company.Id == companyPosition.Company.Id select company).ToList();
    }

    public List<Company> GetCompaniesList(Skill skill)
    {
        var skillList = _context.PositionSkills.Where(s => s.SkillList.Name == skill.Name).ToList();

        var positionsList = _context.CompanyPositions.ToList();

        return (from companyPosition in positionsList from positionsSkill in skillList where positionsSkill.Position.Id == companyPosition.Positions.Id select companyPosition.Company).ToList();
    }
}