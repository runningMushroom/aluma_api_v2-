using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Dto;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/[controller]"), Authorize]
    public class RiskProfileController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public RiskProfileController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult CreateOrUpdate([FromBody] RiskProfileDto dto)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}