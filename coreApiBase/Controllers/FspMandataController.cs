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
    [ApiController, Route("api/v1/fsp/mandate"), Authorize]
    public class FspMandataController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public FspMandataController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult CreateOrUpdate(FspMandateDto dto)
        {
            try
            {
                var mandateExist = _repo.FspMandate
                    .FindByCondition(c => c.ApplicationId == dto.ApplicationId);

                if (mandateExist.Any())
                {
                    // get current step
                    var thisStep = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.FspMandate)
                        .First();

                    // update existing
                    var mandate = mandateExist.First();
                    mandate = _mapper.Map<FspMandateModel>(dto);
                    mandate.StepId = thisStep.Id;

                    _repo.FspMandate.Update(mandate);
                    _repo.Save();
                }
                else
                {
                    var currentStep = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.FspMandate)
                        .First();

                    // create new mandate
                    var mandate = _mapper.Map<FspMandateModel>(dto);
                    mandate.StepId = currentStep.Id;
                    _repo.FspMandate.Update(mandate);

                    currentStep.DataId = mandate.Id;
                    currentStep.Complete = true;
                    currentStep.ActiveStep = false;
                    _repo.ApplicationSteps.Update(currentStep);

                    // set next step as active
                    var nextStep = _repo.ApplicationSteps
                        .ReturnNextStep(mandate.ApplicationId, currentStep.Order);

                    nextStep.ActiveStep = true;
                    _repo.ApplicationSteps.Update(nextStep);

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