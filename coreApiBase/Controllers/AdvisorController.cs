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
    [ApiController, Route("api/v1/advisor"), Authorize]
    public class AdvisorController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public AdvisorController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("advise/for/application/{applicationId}")]
        public IActionResult GetApplicationAdvise(Guid applicationId)
        {
            try
            {
                var advise = _repo.AdvisorAdvise
                    .FindByCondition(c => c.ApplicationId == applicationId)
                    .Include(c => c.AdvisedProducts)
                    .First();

                return Ok(_mapper.Map<AdvisorAdviseDto>(advise));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("advice/required/list"), Authorize(Roles = "Admin,Broker")]
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

        [HttpPost("advice/create"), Authorize(Roles = "Admin,Broker")]
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
                //var digitalKycStep = AdvanceStep(advise.ApplicationId, step);
                step.Complete = true;
                step.ActiveStep = false;
                step.DataId = advise.Id;
                _repo.ApplicationSteps.Update(step);

                // set next step active
                var digitalKycStep = _repo.ApplicationSteps
                    .ReturnNextStep(dto.ApplicationId, step.Order);
                digitalKycStep.ActiveStep = true;
                _repo.ApplicationSteps.Update(digitalKycStep);

                // save all changes
                _repo.Save();

                // get the user that this application belongs to
                var application = _repo.Applications
                    .FindByCondition(c => c.Id == dto.ApplicationId)
                    .Include(c => c.User)
                    .First();

                // do request to kyc to start KYC
                var kycResponse = _repo.KycFactory.InitiateKycFactory(new KycInitiationDto()
                {
                    Consumers = new List<ConsumerDto>()
                    {
                        new ConsumerDto()
                        {
                            LastName = application.User.LastName,
                            FirstName = application.User.FirstName,
                            IdNumber = application.User.IdNumber,
                            Email = application.User.Email,
                            MobileNumber = application.User.MobileNumber,
                            SendEmail = true,
                            IsCurrent = false
                        }
                    }
                });

                // save the factoryId
                digitalKycStep.FactoryId = kycResponse.FactoryId;
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

        [HttpGet("get/kyc/meta/data/{stepId}")]
        public IActionResult GetKycMetaData(Guid stepId)
        {
            try
            {
                var currentStep = _repo.ApplicationSteps
                    .FindByCondition(c => c.Id == stepId)
                    .First();

                // get the users id number & the Kyc Factory ID
                var application = _repo.Applications
                    .FindByCondition(c => c.Id == currentStep.ApplicationId)
                    .Include(c => c.User)
                    .Include(c => c.Steps)
                    .First();

                // get kyc meta data data
                var dto = _repo.KycFactory.GetKycMetaData(new FactoryDetailsDto()
                {
                    idNumber = application.User.IdNumber,
                    factoryId = application.Steps
                        .First(c => c.StepType == ApplicationStepTypesEnum.DigitalKyc)
                        .FactoryId
                });

                // map dto data to model & create data entry
                var kycData = _mapper.Map<KycMetaDataModel>(dto);
                kycData.ApplicationId = application.Id;
                _repo.KycMetaData.Create(kycData);

                // advance to the next step
                currentStep.DataId = kycData.Id;
                currentStep.Complete = true;
                currentStep.ActiveStep = false;
                _repo.ApplicationSteps.Update(currentStep);

                // set next step as active
                var nextStep = _repo.ApplicationSteps
                    .ReturnNextStep(currentStep.ApplicationId, currentStep.Order);

                nextStep.ActiveStep = true;
                _repo.ApplicationSteps.Update(nextStep);

                _repo.Save();

                return StatusCode(201);
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

        private ApplicationStepModel AdvanceStep(Guid applicationId, ApplicationStepModel currentStep)
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