﻿using alumaApi.Dto;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace alumaApi.Controllers
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

        [HttpPost("create/{scheduleType}")]
        public IActionResult Create(string scheduleType)
        {
            try
            {
                var claims = _repo.Jwt.GetUserClaims(Request.Headers[HeaderNames.Authorization].ToString());

                var application = new ApplicationsModel()
                {
                    UserId = claims.UserId,
                    Description =
                        scheduleType == "individual" ? ScheduleTypesEnum.Individual.ToString() :
                        scheduleType == "company" ? ScheduleTypesEnum.Company.ToString() : "Undefined Type"
                };

                _repo.Applications.Create(application);

                _repo.Save();

                var applSteps = _repo.ApplicationSteps.CreateApplicationSteps(scheduleType, application.Id);

                application.Steps = applSteps;

                _repo.Applications.Update(application);

                _repo.Save();

                var dto = _mapper.Map<ApplicationDto>(application);

                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}