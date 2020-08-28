using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.RepoWrapper;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PbVerifyBankValidation;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/bank/account/validation"), Authorize]
    public class BankValidationController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public BankValidationController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut("{applicationId}")]
        public IActionResult PutBankVerification([FromBody] BankVerificationsDto dto, Guid applicationId)
        {
            try
            {
                // get banking step for the given bankverification
                var step = _repo.ApplicationSteps
                    .FindByCondition(
                        c => c.ApplicationId == applicationId &&
                        c.StepType == ApplicationStepTypesEnum.BankValidation)
                    .First();

                // check if bankValidation for this application exists
                var bankValidationExist = _repo.BankVerification
                    .FindByCondition(c => c.ApplicationId == applicationId);

                // append required clientDetails to dto so that it's present when mapping to bav object
                // first check if we have data from digital KYC
                // else use user registration data
                var application = _repo.Applications
                    .FindByCondition(c => c.Id == applicationId)
                    .Include(c => c.User)
                    .Include(c => c.KycMetaData)
                    .First();

                if (application.KycMetaData == null)
                {
                    dto.IdNumber = application.User.IdNumber;
                    dto.Initials = Initials(application.User.FirstName);
                    dto.Surname = application.User.LastName;
                    dto.Reference = $"{application.User.FirstName} {application.User.LastName}";
                }
                else
                {
                    dto.IdNumber = application.KycMetaData.IdNumber;
                    dto.Initials = Initials(application.KycMetaData.FirstNames);
                    dto.Surname = application.KycMetaData.SurName;
                    dto.Reference = $"{application.KycMetaData.FirstNames} {application.KycMetaData.SurName}";
                }

                var jobID = string.Empty;

                if (bankValidationExist.Any())
                {
                    // update existing
                    var bav = bankValidationExist.First();
                    bav = _mapper.Map<BankVerificationsModel>(dto);

                    // start bank validation
                    var validation = _repo.PbVerifyBankValidation.StartBankValidation(dto);
                    bav.JobID = validation.XDSBVS.JobID;
                    bav.ApplicationId = applicationId;
                    jobID = validation.XDSBVS.JobID;

                    _repo.BankVerification.Update(bav);
                }
                else
                {
                    var bav = _mapper.Map<BankVerificationsModel>(dto);
                    bav.StepId = step.Id;
                    bav.ApplicationId = applicationId;

                    // start bank validation
                    var validation = _repo.PbVerifyBankValidation.StartBankValidation(dto);
                    bav.JobID = validation.XDSBVS.JobID;
                    jobID = validation.XDSBVS.JobID;

                    _repo.BankVerification.Create(bav);

                    // we cannot yet set this step to complete.
                    // It's only complete once we've received the bank validation from PbVerify
                    step.DataId = bav.Id;
                    step.Complete = false;
                    step.ActiveStep = false;
                    _repo.ApplicationSteps.Update(step);

                    // set next step as the active step
                    var nextStep = _repo.ApplicationSteps
                        .ReturnNextStep(applicationId, step.Order);

                    nextStep.ActiveStep = true;
                    _repo.ApplicationSteps.Update(nextStep);
                }

                // add check status update to hanfire que - it should start in 3 minutes from now
                BackgroundJob.Schedule(() => _repo.BankVerification
                    .CheckBankValidationStatusByJobId(jobID), TimeSpan.FromMinutes(3));

                _repo.Save();

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private string Initials(string str)
        {
            var newStr = string.Empty;

            str.Split(' ').ToList().ForEach(e => newStr += e[0]);
            return newStr;
        }
    }
}