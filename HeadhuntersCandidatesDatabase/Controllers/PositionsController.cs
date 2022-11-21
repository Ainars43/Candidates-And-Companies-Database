using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        private readonly IValidator _validator;

        public PositionsController(IPositionService positionService, IMapper mapper, IValidator validator)
        {
            _positionService = positionService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult PutPosition(PositionRequest request)
        {
            if (!_validator.IsValid(request.Name))
            {
                return BadRequest();
            }

            var position = _mapper.Map<Position>(request);

            _positionService.Create(position);

            return Created("", position);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetPosition(int positionId)
        {
            var position = _positionService.GetByID(positionId);

            if (!_positionService.Exists(positionId))
            {
                return NotFound();
            }

            return Ok(position);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePosition(int positionId)
        {
            var position = _positionService.GetByID(positionId);

            if (!_positionService.Exists(positionId))
            {
                return NotFound();
            }

            _positionService.Delete(position);

            return Ok();
        }
    }
}
