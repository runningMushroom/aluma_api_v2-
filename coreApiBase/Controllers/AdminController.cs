using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Dto;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.Models.Static;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/admin"), Authorize(Roles = "Admin,Broker")]
    public class AdminController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public AdminController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("list/clients")]
        public IActionResult ListClients()
        {
            try
            {
                // for now we will list all clients
                // what we really want is that when it's a broker, only clients that he worked on should be listed
                // admins should be the only people who can see all clients

                var clientList = _repo.User
                    .FindByCondition(c => c.Role == Roles.Client)
                    .ToList();

                return Ok(clientList);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("list/active/kyc/applications")]
        public IActionResult ListActiveKycApplications()
        {
            try
            {
                // find all application digital kyc steps that are currently on active
                var stepList = _repo.ApplicationSteps
                    .FindByCondition(c => c.StepType == ApplicationStepTypesEnum.DigitalKyc && c.ActiveStep)
                    .ToList();

                // create a list of all the application Id's
                var applicationIds = new List<Guid>();
                stepList.ForEach(c =>
                {
                    applicationIds.Add(c.ApplicationId);
                });

                // retreive all the applications
                var applList = _repo.Applications
                    .FindByCondition(c => applicationIds.Contains(c.Id))
                    .Include(c => c.User)
                    .Include(c => c.Steps)
                    .ToList();

                // map applications to dto & return list
                return Ok(_mapper.Map<List<ApplicationDto>>(applList));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("change/to/manual/kyc/{stepId}")]
        public IActionResult ChangeToManualKyc(Guid stepId)
        {
            try
            {
                var stepList = _repo.ApplicationSteps
                    .FindByCondition(c => c.Id == stepId);

                if (!stepList.Any())
                    throw new NullReferenceException("Could not find Application Step for given ID");

                var step = stepList.First();

                step.StepType = ApplicationStepTypesEnum.ManualKyc;
                step.FactoryStep = null;
                _repo.ApplicationSteps.Update(step);
                _repo.Save();

                return Ok();
            }
            catch (DbUpdateException e)
            {
                return StatusCode(512, "Error while trying to update database");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}