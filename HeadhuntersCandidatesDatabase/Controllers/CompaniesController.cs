using AutoMapper;
using Azure.Core;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Models;
using HeadhuntersCandidatesDatabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ICompanyPositionsService _companyPositionsService;
        private readonly IValidator _validator;

        public CompaniesController(ICompanyService companyService, IMapper mapper, ICompanyPositionsService companyPositionsService, IValidator validator)
        {
            _companyService = companyService;
            _mapper = mapper;
            _companyPositionsService = companyPositionsService;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult PutCompany(Company company)
        {
            if (_companyService.Exists(company))
            {
                return Conflict();
            } 

            if (!_validator.IsValid(company.Name))
            {
                return BadRequest();
            }

            _companyService.Create(company);

            return Created("", company);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCompany(int companyId)
        {
            var company = _companyService.GetByID(companyId);

            if (!_companyService.Exists(companyId))
            {
                return NotFound();
            }

            return Ok(company);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateCompany(int companyId, CompanyRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var company = _mapper.Map<Company>(request);

            var response = _companyService.UpdateCompanyById(companyId, company);

            return Ok(response);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteCompany(int companyId)
        {
            var company = _companyService.GetByID(companyId);

            if (!_companyService.Exists(companyId))
            {
                return NotFound();
            }

            _companyService.Delete(company);

            return Ok();
        }

        [Route("/getallcompanies")]
        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var companies = _companyService.Get().ToList();

            return Ok(companies);
        }

        [Route("/addposition")]
        [HttpPost]
        public IActionResult UpdateCompanyPositions(int companyId, PositionRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var position = _mapper.Map<Position>(request);

            if (!_companyService.Exists(companyId))
            {
                return NotFound();
            }

            CompanyPositions companyPositions = _companyService.AddPosition(companyId, position);

            return Created("", companyPositions);
        }

        [Route("/deleteposition")]
        [HttpDelete]
        public IActionResult DeleteCompanyPosition(int companyId, PositionRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var position = (_mapper.Map<Position>(request));

            if (!_companyService.Exists(companyId))
            {
                return NotFound();
            }

            var companyPosition = _companyService.FindPosition(companyId, position);

            _companyPositionsService.Delete(companyPosition);

            return Ok();
        }

        [Route("/getcompanypositions")]
        [HttpGet]
        public IActionResult GetCompanyPositions(int companyId)
        {
            var company = _companyService.GetByID(companyId);

            if (!_companyService.Exists(companyId))
            {
                return NotFound();
            }

            var positionList = _companyService.GetCompanyPositionsList(company);

            return Ok(positionList);
        }

        [Route("/getbyposition")]
        [HttpGet]
        public IActionResult GetCompaniesByPosition(PositionRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var position = (_mapper.Map<Position>(request));

            var companiesList = _companyService.GetCompaniesList(position);

            return Ok(companiesList);
        }

        [Route("/getcompaniesbyskill")]
        [HttpGet]
        public IActionResult GetCompaniesBySkill(SkillRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var skill = _mapper.Map<Skill>(request);

            var companiesList = _companyService.GetCompaniesList(skill);

            return Ok(companiesList);
        }
    }
}
