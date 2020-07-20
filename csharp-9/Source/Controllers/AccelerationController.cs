﻿using System;
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
    public class AccelerationController : ControllerBase
    {
        private readonly IAccelerationService _service;
        private readonly IMapper _mapper;
        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll([FromQuery]int? companyId = null)
        {
            if (companyId.HasValue)
                return Ok(_mapper.Map<List<AccelerationDTO>>(_service.FindByCompanyId(companyId.Value)));
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            return Ok(_mapper.Map<AccelerationDTO>(_service.FindById(id)));
        }

        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody]AccelerationDTO value)
        {
            var accelerationSave = _service.Save(_mapper.Map<Acceleration>(value));
            return Ok(_mapper.Map<AccelerationDTO>(accelerationSave));
        }
    }
}
