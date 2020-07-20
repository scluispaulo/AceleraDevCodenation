using System.Collections.Generic;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _service;
        private readonly IMapper _mapper;
        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll([FromQuery]int? accelerationId = null, [FromQuery]int? userId = null)
        {
            if(accelerationId.HasValue && userId.HasValue)
                return Ok(_mapper.Map<List<ChallengeDTO>>(_service.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value)));
            else
                return NoContent();
        }

         [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody]ChallengeDTO value)
        {
            var challengeSave = _service.Save(_mapper.Map<Models.Challenge>(value));
            return Ok(_mapper.Map<ChallengeDTO>(challengeSave));
        }
    }
}
