using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;
        private readonly IValidator _validator;

        public SkillsController(ISkillService skillService, IMapper mapper, IValidator validator)
        {
            _skillService = skillService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult PutSkill(SkillRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var skill = _mapper.Map<Skill>(request);

            _skillService.Create(skill);

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetSkill(int skillId)
        {
            var skill = _skillService.GetByID(skillId);

            if (!_skillService.Exists(skillId))
            {
                return NotFound();
            }

            return Ok(skill);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteSkill(int skillId)
        {
            var skill = _skillService.GetByID(skillId);

            if (!_skillService.Exists(skillId))
            {
                return NotFound();
            }

            _skillService.Delete(skill);

            return Ok();
        }
    }
}
