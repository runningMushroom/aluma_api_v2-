using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using alumaApi.Dto;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.RepoWrapper;
using AutoMapper;
using KycFactory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/advisor/advice"), Authorize(Roles = "Admin,Broker")]
    public class AdvisorAdviseController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public AdvisorAdviseController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("test"), AllowAnonymous]
        public IActionResult test()
        {
            //_repo.Applications.AdvanceStep();
            try
            {
                bool a = _repo.KycFactory.testException();
                return Ok();
            }
            catch (HttpRequestException e)
            {
                return StatusCode(503, e.Message);
            }
        }

        [HttpGet("required/list")]
        public IActionResult ListApplicationsWithoutAdvice()
        {
            try
            {
                // find all advisor advice application steps that haven't been completed
                var stepList = _repo.ApplicationSteps
                    .FindByCondition(
                        c => c.StepType == ApplicationStepTypesEnum.AdvisorAdvise
                        && c.Complete == false)
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
                    .ToList();

                // map applications to dto & return list
                return Ok(_mapper.Map<List<ApplicationDto>>(applList));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] AdvisorAdviseDto dto)
        {
            try
            {
                // get the advisor step object from the db for the supplied application id
                var step = _repo.ApplicationSteps
                    .FindByCondition(c => c.ApplicationId == dto.ApplicationId)
                    .AsNoTracking()
                    .First();

                // do not proceed if step is null
                if (step == null) return StatusCode(404, "Step item for given application id not found");

                // map advise & apped stepId
                var advise = _mapper.Map<AdvisorAdviseModel>(dto);
                advise.StepId = step.Id;

                // add advise object to db
                _repo.AdvisorAdvise.Create(advise);

                // update the application steps
                var digitalKycStep = AdvanceStep(advise.ApplicationId, step);

                // save all changes
                _repo.Save();

                // get the user that this application belongs to
                var application = _repo.Applications
                    .FindByCondition(c => c.Id == dto.ApplicationId)
                    .First();

                var user = _repo.User
                    .FindByCondition(c => c.Id == application.UserId)
                    .First();

                // do request to kyc to start KYC
                //var kycResponse = _repo.KycFactory.InitiateKycFactory(new KycInitiationDto()
                //{
                //    Consumers = new List<ConsumerDto>()
                //    {
                //        new ConsumerDto()
                //        {
                //            LastName = user.LastName,
                //            FirstName = user.FirstName,
                //            IdNumber = user.IdNumber,
                //            Email = user.Email,
                //            MobileNumber = user.MobileNumber,
                //            SendEmail = true,
                //            IsCurrent = false
                //        }
                //    }
                //});

                // save the factoryId

                //digitalKycStep.FactoryId = kycResponse.FactoryId;
                digitalKycStep.FactoryId = 1714;
                _repo.ApplicationSteps.Update(digitalKycStep);
                _repo.Save();

                return StatusCode(201);
            }
            catch (NullReferenceException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (InvalidEnumArgumentException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(501, e.Message);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(503, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private ApplicationStepModel AdvanceStep(Guid applicationId, ApplicationStepModel step)
        {
            var application = _repo.Applications
                .FindByCondition(c => c.Id == applicationId)
                .First();

            switch (step.StepType)
            {
                case ApplicationStepTypesEnum.AdvisorAdvise:
                    return CompleteAdvisorAdvise(applicationId, step);

                default:
                    throw new InvalidEnumArgumentException("Invalid Application step type");
            }
        }

        private ApplicationStepModel CompleteAdvisorAdvise(Guid applicationId, ApplicationStepModel currentStep)
        {
            // change the current step (advisor advice) to complete & update
            currentStep.ActiveStep = false;
            currentStep.Complete = true;
            _repo.ApplicationSteps.Update(currentStep);

            // set next step (digital KYC) to active & update
            var nextStep = _repo.ApplicationSteps
                .FindByCondition(c => c.ApplicationId == applicationId && c.StepType == ApplicationStepTypesEnum.DigitalKyc)
                .First();
            if (nextStep == null) throw new NullReferenceException("Application not found");

            nextStep.ActiveStep = true;

            // update changes
            _repo.ApplicationSteps.Update(nextStep);

            return nextStep;
        }
    }
}