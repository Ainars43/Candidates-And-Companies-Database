using AutoMapper;
using Azure.Core;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/positionsskills")]
    [ApiController]
    public class PositionsSkillsController : ControllerBase
    {
        private readonly IPositionSkillsService _positionSkillsService;
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;
        private readonly IValidator _validator;

        public PositionsSkillsController(IPositionSkillsService positionSkillsService, IMapper mapper, IPositionService positionService, IValidator validator)
        {
            _positionSkillsService = positionSkillsService;
            _mapper = mapper;
            _positionService = positionService;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult PutPositionSkill(PositionSkills positionSkills)
        {
            if (!_validator.IsValid(positionSkills.Position.Name) || !_validator.IsValid(positionSkills.SkillList.Name))
            {
                return BadRequest();
            }

            _positionSkillsService.Create(positionSkills);

            return CreatedAtAction("GetPositionSkills", new { id = positionSkills.Id}, positionSkills);
        }

        [Route("{position}")]
        [HttpGet]
        public IActionResult GetPositionSkills(PositionRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var position = _mapper.Map<Position>(request);

            if (!_positionService.Exists(position))
            {
                return NotFound();
            }

            var positionSkills = _positionSkillsService.FindPosition(position);

            return Ok(positionSkills);
        }

        [Route("{position}")]
        [HttpDelete]
        public IActionResult DeletePositionSkills(PositionRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var position = _mapper.Map<Position>(request);

            if (!_positionService.Exists(position))
            {
                return NotFound();
            }

            var positionSkills = _positionSkillsService.FindPosition(position);

            _positionSkillsService.Delete(positionSkills);

            return Ok();
        }
    }
}
