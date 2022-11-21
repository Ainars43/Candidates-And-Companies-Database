using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;
        private readonly ICandidateSkillsetService _candidateSkillsetService;
        private readonly IValidator _validator;

        public CandidatesController(ICandidateService candidateService, IMapper mapper, ICandidateSkillsetService candidateSkillsetService, IValidator validator)
        {
            _candidateService = candidateService;
            _mapper = mapper;
            _candidateSkillsetService = candidateSkillsetService;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult PutCandidate(Candidate candidate)
        {
            if (_candidateService.Exists(candidate))
            {
                return Conflict();
            }

            if (!_validator.IsValid(candidate.Name))
            {
                return BadRequest();
            }

            _candidateService.Create(candidate);

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCandidate(int candidateId)
        {
            var candidate = _candidateService.GetByID(candidateId);

            if (!_candidateService.Exists(candidateId))
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateCandidate(CandidateRequest request, int id)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var candidate = _mapper.Map<Candidate>(request);

            var result = _candidateService.UpdateCandidateById(id, candidate);

            return Ok(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteCandidate(int candidateId)
        {
            var candidate = _candidateService.GetByID(candidateId);

            if (!_candidateService.Exists(candidateId))
            {
                return NotFound();
            }

            _candidateService.Delete(candidate);

            return Ok();
        }

        [Route("/getallcandidates")]
        [HttpGet]
        public IActionResult GetAllCandidates()
        {
            var candidates = _candidateService.Get().ToList();

            return Ok(candidates);
        }

        [Route("/addskill")]
        [HttpPost]
        public IActionResult UpdateCandidateSkills(int candidateId, SkillRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var skill = _mapper.Map<Skill>(request);

            if (!_candidateService.Exists(candidateId))
            {
                return NotFound();
            }

            CandidateSkillset candidateSkillset = _candidateService.AddSkill(candidateId, skill);

            return Created("", candidateSkillset);
        }

        [Route("/deleteskill")]
        [HttpDelete]
        public IActionResult DeleteCandidateSkill(int candidateId, SkillRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var skill = _mapper.Map<Skill>(request);

            if (!_candidateService.Exists(candidateId))
            {
                return NotFound();
            }

            var skillset = _candidateService.FindSkillset(candidateId, skill);

            _candidateSkillsetService.Delete(skillset);

            return Ok();
        }

        [Route("/getandidatesbyskill")]
        [HttpGet]
        public IActionResult GetCandidatesBySkill(SkillRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var skill = _mapper.Map<Skill>(request);

            var candidatesList = _candidateService.GetCandidatesList(skill);

            return Ok(candidatesList);
        }
    }
}
