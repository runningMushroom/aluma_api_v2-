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
    [ApiController, Route("api/v1/required/secondary/schedules"), Authorize]
    public class RequiredSecondarySchedulesController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public RequiredSecondarySchedulesController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("{applicationId}")]
        public IActionResult NotRequired(Guid applicationId)
        {
            try
            {
                var thisStep = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == applicationId &&
                            c.StepType == ApplicationStepTypesEnum.SecondarySchedule)
                        .First();

                thisStep.Complete = true;
                thisStep.ActiveStep = false;
                _repo.ApplicationSteps.Update(thisStep);

                var nextStep = _repo.ApplicationSteps
                        .ReturnNextStep(applicationId, thisStep.Order);

                nextStep.ActiveStep = true;
                _repo.ApplicationSteps.Update(nextStep);

                _repo.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult CreateOrUpdate([FromBody] RequiredSecondarySchedulesDto dto)
        {
            try
            {
                var requimentsExist = _repo.RequiredSecondarySchedules
                    .FindByCondition(c => c.ApplicationId == dto.ApplicationId);

                var thisStep = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.SecondarySchedule)
                        .First();

                if (requimentsExist.Any())
                {
                    // update
                    var requirements = requimentsExist.First();
                    requirements = _mapper.Map<RequiredSecondarySchedulesModel>(dto);
                    requirements.StepId = thisStep.Id;

                    _repo.RequiredSecondarySchedules.Update(requirements);
                    _repo.Save();
                }
                else
                {
                    var requirements = _mapper.Map<RequiredSecondarySchedulesModel>(dto);
                    requirements.StepId = thisStep.Id;
                    _repo.RequiredSecondarySchedules.Create(requirements);

                    thisStep.DataId = requirements.Id;
                    thisStep.Complete = true;
                    thisStep.ActiveStep = false;
                    _repo.ApplicationSteps.Update(thisStep);

                    var nextStep = _repo.ApplicationSteps
                        .ReturnNextStep(requirements.ApplicationId, thisStep.Order);

                    nextStep.ActiveStep = true;
                    _repo.ApplicationSteps.Update(nextStep);

                    _repo.Save();
                }

                // send out a email and sms for each person who haven't yet completed their secodnary Schedule

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}