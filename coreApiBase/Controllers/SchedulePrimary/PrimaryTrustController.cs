using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Enum;
using alumaApi.Models.Schedules;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alumaApi.Controllers.SchedulePrimary
{
    [ApiController, Route("api/v1/schedule/primary/trust"), Authorize]
    public class PrimaryTrustController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public PrimaryTrustController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult CreateOrUpdate([FromBody] PrimaryTrustModel dto)
        {
            try
            {
                // determine if a schedule already exists
                var scheduleQuery = _repo.PrimaryTrust
                    .FindByCondition(c => c.ApplicationId == dto.ApplicationId);

                if (!scheduleQuery.Any())
                {
                    var schedule = _repo.PrimaryTrust
                        .FindByCondition(c => c.Id == dto.Id)
                        //.Include(c => c.BankDetails)
                        .Include(c => c.Details)
                            .ThenInclude(c => c.AdressItems)
                        .Include(c => c.Entity)
                        .Include(c => c.TaxResidency)
                            .ThenInclude(c => c.TaxResidencyItems)
                        .First();

                    schedule = _mapper.Map<PrimaryTrustModel>(dto);
                    _repo.PrimaryTrust.Update(schedule);
                    _repo.Save();
                }
                else
                {
                    var step = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.PrimarySchedule)
                        .First();

                    var schedule = _mapper.Map<PrimaryTrustModel>(dto);
                    _repo.PrimaryTrust.Create(schedule);

                    step.DataId = schedule.Id;

                    // update application steps so that we can go to the next step
                    step.Complete = true;
                    step.ActiveStep = false;
                    _repo.ApplicationSteps.Update(step);

                    var nextStep = _repo.ApplicationSteps.ReturnNextStep(dto.ApplicationId, step.Order);
                    nextStep.ActiveStep = true;
                    _repo.ApplicationSteps.Update(nextStep);

                    _repo.Save();
                }

                if (dto.TaxResidency.InternationalObligations == "InternationalObligationsTrue")
                    _repo.ApplicationSteps.AddIrsw9Step(dto.ApplicationId);

                if (dto.TaxResidency.UsOther == "UsOtherTrue")
                    _repo.ApplicationSteps.AddIrsw8beneStep(dto.ApplicationId);

                if (dto.Entity.ComplaintFi == "x" &&
                    !_repo.ApplicationSteps.FindByCondition(
                        c => c.ApplicationId == dto.ApplicationId &&
                        c.StepType == ApplicationStepTypesEnum.Irsw8bene)
                    .Any()
                    )
                {
                    _repo.ApplicationSteps.AddIrsw8beneStep(dto.ApplicationId);
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