using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Dto;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.Repositories;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/dividend/tax"), Authorize]
    public class DividendTaxController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public DividendTaxController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult CreateOrUpdate(DividendTaxDto dto)
        {
            try
            {
                // check if a dividend for given application ID exists
                var dividendEsist = _repo.DividendTax
                    .FindByCondition(
                        c => c.ApplicationId == dto.ApplicationId);

                if (dividendEsist.Any())
                {
                    // get current step
                    var thisStep = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.Dividens)
                        .First();

                    // update existing
                    var dividend = dividendEsist.First();
                    dividend = _mapper.Map<DividendTaxModel>(dto);
                    dividend.StepId = thisStep.Id;

                    _repo.DividendTax.Update(dividend);
                    _repo.Save();
                }
                else
                {
                    // Get current application step item
                    var currentStep = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.Dividens)
                        .First();

                    // create new dividends
                    var dividend = _mapper.Map<DividendTaxModel>(dto);
                    dividend.StepId = currentStep.Id;
                    _repo.DividendTax.Create(dividend);

                    currentStep.DataId = dividend.Id;
                    currentStep.Complete = true;
                    currentStep.ActiveStep = false;
                    _repo.ApplicationSteps.Update(currentStep);

                    // set next step as active
                    var nextStep = _repo.ApplicationSteps
                        .ReturnNextStep(dividend.ApplicationId, currentStep.Order);
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