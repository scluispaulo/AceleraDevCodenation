using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _service;
        private readonly IMapper _mapper;
        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll([FromQuery]int? challengeId = null, [FromQuery]int? accelerationId = null)    
        {
            if (challengeId.HasValue && accelerationId.HasValue)
                return Ok(_mapper.Map<List<SubmissionDTO>>(_service.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value)));
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<decimal> GetHigherScore(int? challengeId = null)
        {
            if(challengeId.HasValue)
                return Ok(_service.FindHigherScoreByChallengeId(challengeId.Value));
            else
                return NoContent();
        }

        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            var submissionSave = _service.Save(_mapper.Map<Submission>(value));
            return Ok(_mapper.Map<SubmissionDTO>(submissionSave));
        }
    }
}
