using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;

namespace vueBuilderApi.Controllers
{
    [ApiController, Route("api/v1/application"), Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public ApplicationController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create()
        {
            try
            {
                var token = Request.Headers[HeaderNames.Authorization].ToString();

                var claims = _repo.Jwt.GetUserClaims(token);

                return Ok(claims);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}