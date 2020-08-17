using System;
using System.Collections.Generic;
using AutoMapper;
using alumaApi.Dto;
using alumaApi.RepoWrapper;
using alumaApi.Static;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using alumaApi.Models;
using Entities.Dto;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/user"), Authorize]
    public class UserController : Controller
    {
        private readonly IWrapper _repo;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly SystemSettingsDto _settings;

        public UserController(IWrapper wrapper, ILogger<UserController> logger, IMapper mapper, SystemSettingsDto settings)
        {
            _repo = wrapper;
            _logger = logger;
            _mapper = mapper;
            _settings = settings;
        }

        [HttpPost("create"), AllowAnonymous]
        public IActionResult Create([FromBody] UserDto dto)
        {
            try
            {
                // map dto to user obj
                var user = _mapper.Map<UserModel>(dto);

                // create client
                _repo.User.Create(user);

                // create otp

                // send otp

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}