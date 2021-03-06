﻿using alumaApi.Dto;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.RepoWrapper;
using AutoMapper;
using Hangfire;
using KycFactory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/application"), Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public ApplicationController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("test/pdf/filler"), AllowAnonymous]
        public IActionResult TestPdfFiller()
        {
            return Ok(_mapper.Map<ApplicationDocumentsDto>(_repo.Applications.PopulateTestDocument()));
        }

        [HttpPost("create/{scheduleType}")]
        public IActionResult Create(string scheduleType)
        {
            try
            {
                var claims = _repo.Jwt.GetUserClaims(Request.Headers[HeaderNames.Authorization].ToString());

                var application = new ApplicationsModel()
                {
                    UserId = claims.UserId,
                    Description =
                        scheduleType == "individual" ? ScheduleTypesEnum.Individual.ToString() :
                        scheduleType == "company" ? ScheduleTypesEnum.Company.ToString() :
                        scheduleType == "trust" ? ScheduleTypesEnum.Trust.ToString() : "Undefined Type"
                };

                _repo.Applications.Create(application);

                _repo.Save();

                var applSteps = _repo.ApplicationSteps.CreateApplicationSteps(scheduleType, application.Id);

                application.Steps = applSteps;

                _repo.Applications.Update(application);

                _repo.Save();

                var dto = _mapper.Map<ApplicationsDto>(application);

                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("list")]
        public IActionResult GetList()
        {
            try
            {
                var claims = _repo.Jwt.GetUserClaims(Request.Headers[HeaderNames.Authorization].ToString());

                var applList = _repo.Applications
                    .FindByCondition(c => c.UserId == claims.UserId)
                    .Include(c => c.Steps)
                    .ToList();

                return Ok(_mapper.Map<List<ApplicationsDto>>(applList));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var claims = _repo.Jwt.GetUserClaims(Request.Headers[HeaderNames.Authorization].ToString());

                var application = _repo.Applications
                    .FindByCondition(c => c.UserId == claims.UserId && c.Id == id)
                    .Include(c => c.Steps);

                if (!application.Any())
                    return StatusCode(404, "Application not found");

                return Ok(_mapper.Map<ApplicationsDto>(application.First()));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("current/step/{applicationId}")]
        public IActionResult CurrentStep(Guid applicationId)
        {
            try
            {
                var application = _repo.Applications
                    .FindByCondition(c => c.Id == applicationId)
                    .Include(c => c.Steps);

                if (!application.Any())
                    throw new NullReferenceException("Could not find Application Step for given ID");

                var currentStep = application.First().Steps.First(c => c.ActiveStep);

                return Ok(_mapper.Map<ApplicationStepsDto>(currentStep));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("skip/current/step/{applicationId}")]
        public IActionResult SkipStep(Guid applicationId)
        {
            try
            {
                SkipCurrentStep(applicationId);

                return Ok(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("kyc/event/update"), AllowAnonymous]
        public IActionResult KycEventUpdate([FromBody] KycEventDto dto)
        {
            if (dto.CurrentStep.ToLower() == "complete")
            {
                // get the application step containing this factory id
                var currentStep = _repo.ApplicationSteps
                    .FindByCondition(c => c.FactoryId == dto.FactoryId)
                    .First();

                // get the application & user data
                var application = _repo.Applications
                    .FindByCondition(c => c.Id == currentStep.ApplicationId)
                    .Include(c => c.User)
                    .First();

                // get kyc meta data data
                var metDataDto = _repo.KycFactory.GetKycMetaData(new FactoryDetailsDto()
                {
                    idNumber = application.User.IdNumber,
                    factoryId = currentStep.FactoryId
                });

                // map dto data to model & create data entry
                var kycData = _mapper.Map<KycMetaDataModel>(dto);
                _repo.KycMetaData.Create(kycData);

                // advance to the next step
                currentStep.DataId = kycData.Id;
                currentStep.Complete = true;
                currentStep.ActiveStep = false;
                _repo.ApplicationSteps.Update(currentStep);

                // set next step as active
                var nextStep = _repo.ApplicationSteps
                    .ReturnNextStep(application.Id, currentStep.Order);

                nextStep.ActiveStep = true;
                _repo.ApplicationSteps.Update(nextStep);

                _repo.Save();
            }
            else
            {
                // get the application step & update the last completed kyc step
                var step = _repo.ApplicationSteps
                    .FindByCondition(c => c.FactoryId == dto.FactoryId)
                    .First();

                step.FactoryStep = dto.CurrentStep.ToLower();
                _repo.ApplicationSteps.Update(step);
                _repo.Save();
            }

            return Ok();
        }

        [HttpGet("documents/{documentId}")]
        public IActionResult GetDocumentById(Guid documentId)
        {
            try
            {
                var doc = _repo.ApplicationDocuments
                    .FindByCondition(c => c.Id == documentId)
                    .First();

                return StatusCode(200, _mapper.Map<ApplicationDocumentsDto>(doc));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("documents/list/{applicationId}")]
        public IActionResult DocumentsList(Guid applicationId)
        {
            try
            {
                var documentList = _repo.ApplicationDocuments
                    .FindByCondition(c => c.ApplicationId == applicationId)
                    .ToList();

                //Dictionary<Guid, string> docList = new Dictionary<Guid, string>();
                var dtoList = _mapper.Map<List<ApplicationDocumentsDto>>(documentList);
                dtoList.ForEach(d => d.DocuemtnData = null);

                //documentList.ForEach(doc => docList[doc.Id] = doc.Name);

                return Ok(dtoList);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("upload/documents")]
        public IActionResult UploadDocuments([FromBody] ApplicationDocumentsDto dto)
        {
            try
            {
                // set manual applicaiton to complete true if 1 or more docs saved
                if (dto != null)
                {
                    var docuemnt = _mapper.Map<ApplicationDocumentsModel>(dto);

                    _repo.ApplicationDocuments.Create(docuemnt);

                    var step = _repo.ApplicationSteps
                        .FindByCondition(
                            c => c.ApplicationId == docuemnt.ApplicationId &&
                            c.StepType == ApplicationStepTypesEnum.ManualKyc)
                        .First();

                    step.Complete = true;
                    _repo.ApplicationSteps.Update(step);

                    _repo.Save();
                }

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("primary/forms/completed/{applicationId}")]
        public IActionResult PrimaryFormsComplete(Guid applicationId)
        {
            try
            {
                var applciation = _repo.Applications
                    .FindByCondition(c => c.Id == applicationId)
                    .First();

                applciation.PrimaryFormsComplete = true;
                _repo.Applications.Update(applciation);
                _repo.Save();

                // check if there was a mismatch between the clients risk profile & selected products

                // if the bankvalidation is complete proceed to create the required documents

                BackgroundJob.Enqueue(() => _repo.Applications.ProcessApplication(applicationId));
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("process/now/{applicationId}")]
        [AutomaticRetry(Attempts = 0)]
        public IActionResult ProcessApplication(Guid applicationId)
        {
            try
            {
                BackgroundJob.Enqueue(() => _repo.Applications.ProcessApplication(applicationId));
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("signing/right/otp/{applicationId}")]
        public IActionResult RequestSigningRightsOtp(Guid applicationId)
        {
            try
            {
                var claims = _repo.Jwt.GetUserClaims(Request.Headers[HeaderNames.Authorization].ToString());

                // get the client
                var user = _repo.User
                    .FindByCondition(c => c.Id == claims.UserId)
                    .First();

                // create otp
                var otp = new OtpModel()
                {
                    UserId = user.Id,
                    ClientEmail = user.Email,
                    OtpType = OtpTypesEnum.SignDocument,
                    Otp = _repo.BulkSms.CreateOtp(),
                    RelatedDataId = applicationId,
                };
                _repo.Otp.Create(otp);
                _repo.Save();

                // send otp
                var otpSent = _repo.BulkSms.SendOtop(user.MobileNumber, $"Give Aluma Capital the " +
                    $"rights to digitally sign application documents with OTP: {otp.Otp}");

                if (!otpSent)
                    return StatusCode(500, "Couldn't send OTP, Please retry or contact support");

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("signing/right/otp/{email}/{otp}/{applicationId}")]
        [AutomaticRetry(Attempts = 0)]
        public IActionResult VerifySigningRightsOtp(string email, string otp, Guid applicationId)
        {
            try
            {
                var otpObjList = _repo.Otp.FindByCondition(
                    c => c.ClientEmail == email &&
                    c.OtpType == OtpTypesEnum.SignDocument &&
                    c.RelatedDataId == applicationId &&
                    c.Otp == otp);

                if (!otpObjList.Any())
                    return StatusCode(404, "OTP not found");

                var otpObj = otpObjList.First();

                //if (otpObj.Otp != otp)
                //    return StatusCode(403, "OTP Invalid");

                // get the applicaiton
                var application = _repo.Applications
                    .FindByCondition(c => c.Id == applicationId)
                    .First();

                application.AllowSignature = true;
                _repo.Applications.Update(application);
                _repo.Save();

                _repo.Otp.Delete(otpObj);
                _repo.Save();

                BackgroundJob.Enqueue(() => _repo.Applications.ProcessApplication(applicationId));

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private void SkipCurrentStep(Guid applicationId)
        {
            // get the current step for this application
            var currentStep = _repo.ApplicationSteps
                .FindByCondition(c => c.ApplicationId == applicationId && c.ActiveStep)
                .First();

            currentStep.ActiveStep = false;
            _repo.ApplicationSteps.Update(currentStep);

            // get the next step to be completed
            var nextStep = ReturnNextStep(applicationId, currentStep.Order);
            nextStep.ActiveStep = true;
            _repo.ApplicationSteps.Update(nextStep);

            _repo.Save();
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
    }
}