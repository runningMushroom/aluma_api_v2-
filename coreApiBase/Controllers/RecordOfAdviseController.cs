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
    [ApiController, Route("api/v1/record/of/advise"), Authorize]
    public class RecordOfAdviseController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public RecordOfAdviseController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult CreateOrEdit([FromBody] RecordOfAdviseDto dto)
        {
            try
            {
                // check of a record of advise already exists for this application
                var roaExist = _repo.RecordOfAdvise
                    .FindByCondition(c => c.ApplicationId == dto.ApplicationId);

                if (roaExist.Any())
                {
                    // get & update existing
                    var roa = roaExist.First();
                    roa = _mapper.Map<RecordOfAdviseModel>(dto);
                    _repo.RecordOfAdvise.Update(roa);
                    _repo.Save();
                }
                else
                {
                    // get the current step
                    var currentStep = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.RecordOfAdvice)
                        .First();

                    // create a new roa
                    var roa = _mapper.Map<RecordOfAdviseModel>(dto);
                    roa.StepId = currentStep.Id;
                    _repo.RecordOfAdvise.Create(roa);

                    currentStep.DataId = roa.Id;
                    currentStep.ActiveStep = false;
                    currentStep.Complete = true;

                    // get next step and mark it as active
                    var nextStep = _repo.ApplicationSteps
                        .ReturnNextStep(roa.ApplicationId, currentStep.Order);
                    nextStep.ActiveStep = true;
                    _repo.ApplicationSteps.Update(nextStep);

                    // save changes
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