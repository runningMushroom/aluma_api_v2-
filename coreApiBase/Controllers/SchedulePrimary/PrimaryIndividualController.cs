using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Dto.Schedules;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.Models.Schedules;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alumaApi.Controllers.SchedulePrimary
{
    [ApiController, Route("api/v1/schedule/primary/individual"), Authorize]
    public class PrimaryIndividualController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public PrimaryIndividualController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult CreateOrUpdate([FromBody] PrimaryIndividualDto dto)
        {
            try
            {
                // determine if a schedule already exists
                var scheduleExist = _repo.PrimaryIndividual
                    .FindByCondition(c => c.ApplicationId == dto.ApplicationId);

                if (scheduleExist.Any())
                {
                    var schedule = _repo.PrimaryIndividual
                        .FindByCondition(c => c.ApplicationId == dto.ApplicationId)
                        .Include(c => c.ClientDetails)
                        .Include(c => c.ContactDetails)
                        .Include(c => c.PurposeAndFunding)
                        .Include(c => c.TaxResidency)
                        .First();

                    schedule = _mapper.Map<PrimaryIndividualModel>(dto);
                    _repo.PrimaryIndividual.Update(schedule);
                    _repo.Save();
                }
                else
                {
                    // get the step related to this application & schedule
                    var step = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == dto.ApplicationId &&
                            c.StepType == Enum.ApplicationStepTypesEnum.PrimarySchedule)
                        .First();

                    var schedule = _mapper.Map<PrimaryIndividualModel>(dto);
                    schedule.StepId = step.Id;

                    _repo.PrimaryIndividual.Create(schedule);
                    step.DataId = schedule.Id;
                    _repo.ApplicationSteps.Update(step);

                    // update application steps so that we can go to the next step
                    step.Complete = true;
                    step.ActiveStep = false;
                    _repo.ApplicationSteps.Update(step);

                    var nextStep = ReturnNextStep(dto.ApplicationId, step.Order);
                    nextStep.ActiveStep = true;
                    _repo.ApplicationSteps.Update(nextStep);

                    _repo.Save();
                }

                //_repo.Save();

                // if the client answered yes to in any of the US related tax residency fields
                // we need to add some steps to the application
                if (dto.TaxResidency.UsCitizen)
                {
                    // add Irsw9 step
                    AddIrsw9Step(dto.ApplicationId);
                }
                if (dto.TaxResidency.UsRelinquished)
                {
                    // add LossOfNationality step
                    AddLossOfNationalityStep(dto.ApplicationId);
                }
                if (dto.TaxResidency.UsOther)
                {
                    // add Irsw8bene step
                    AddIrsw8beneStep(dto.ApplicationId);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private ApplicationStepModel ReturnNextStep(Guid applicationId, int currentStep)
        {
            var step = _repo.ApplicationSteps
                .FindByCondition(
                    c => c.ApplicationId == applicationId &&
                    c.Order == (currentStep + 1));

            if (!step.Any()) throw new NullReferenceException("Couldn't find next step");

            return step.First();
        }

        private void AddIrsw9Step(Guid applicationId)
        {
            // get the signature step and incriment it's order with 1
            var signatureStep = SignatureStep(applicationId);
            var stepPosition = signatureStep.Order;
            signatureStep.Order += 1;
            _repo.ApplicationSteps.Update(signatureStep);

            // add new step with the order position that the signature step use to have
            var newStep = new ApplicationStepModel()
            {
                ActiveStep = false,
                ApplicationId = applicationId,
                Complete = false,
                Order = stepPosition,
                StepType = ApplicationStepTypesEnum.Irsw9
            };
            _repo.ApplicationSteps.Create(newStep);
            _repo.Save();
        }

        private void AddLossOfNationalityStep(Guid applicationId)
        {
            // get the signature step and incriment it's order with 1
            var signatureStep = SignatureStep(applicationId);
            var stepPosition = signatureStep.Order;
            signatureStep.Order += 1;
            _repo.ApplicationSteps.Update(signatureStep);

            // add new step with the order position that the signature step use to have
            var newStep = new ApplicationStepModel()
            {
                ActiveStep = false,
                ApplicationId = applicationId,
                Complete = false,
                Order = stepPosition,
                StepType = ApplicationStepTypesEnum.LossOfNationality
            };
            _repo.ApplicationSteps.Create(newStep);
            _repo.Save();
        }

        private void AddIrsw8beneStep(Guid applicationId)
        {
            // get the signature step and incriment it's order with 1
            var signatureStep = SignatureStep(applicationId);
            var stepPosition = signatureStep.Order;
            signatureStep.Order += 1;
            _repo.ApplicationSteps.Update(signatureStep);

            // add new step with the order position that the signature step use to have
            var newStep = new ApplicationStepModel()
            {
                ActiveStep = false,
                ApplicationId = applicationId,
                Complete = false,
                Order = stepPosition,
                StepType = ApplicationStepTypesEnum.Irsw8bene
            };
            _repo.ApplicationSteps.Create(newStep);
            _repo.Save();
        }

        private ApplicationStepModel SignatureStep(Guid applicationId)
        {
            return _repo.ApplicationSteps
                .FindByCondition(
                    c => c.ApplicationId == applicationId &&
                    c.StepType == ApplicationStepTypesEnum.Signature)
                .First();
        }
    }
}