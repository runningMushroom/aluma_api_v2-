using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Dto;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/risk/profile"), Authorize]
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
                // check if a riskprofile for given application ID exists
                var riskExist = _repo.RiskProfile
                    .FindByCondition(c => c.ApplicationId == dto.ApplicationId);

                if (riskExist.Any())
                {
                    // update existING
                    var riskProfile = riskExist.First();
                    riskProfile = _mapper.Map<RiskProfileModel>(dto);
                    _repo.RiskProfile.Update(riskProfile);
                    _repo.Save();
                }
                else
                {
                    // Get current application step item
                    var currentStep = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.RiskProfile)
                        .First();

                    // create new riskprofile
                    var riskProfile = _mapper.Map<RiskProfileModel>(dto);
                    riskProfile.StepId = currentStep.Id;
                    _repo.RiskProfile.Create(riskProfile);

                    // update current step
                    currentStep.DataId = riskProfile.Id;
                    currentStep.Complete = true;
                    currentStep.ActiveStep = false;
                    _repo.ApplicationSteps.Update(currentStep);

                    // set next step as active
                    var nextStep = _repo.ApplicationSteps
                        .ReturnNextStep(riskProfile.ApplicationId, currentStep.Order);
                    nextStep.ActiveStep = true;
                    _repo.ApplicationSteps.Update(nextStep);

                    // update repo
                    _repo.Save();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}