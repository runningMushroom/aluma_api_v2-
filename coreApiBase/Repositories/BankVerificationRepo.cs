using alumaApi.Data;
using alumaApi.Enum;
using alumaApi.Models;
using Hangfire;
using PbVerifyBankValidation;
using System;
using System.Linq;

namespace alumaApi.Repositories
{
    public interface IBankVerificationRepo : IRepoBase<BankVerificationsModel>
    {
        void CheckBankValidationStatusByJobId(string jobId);
    }

    public class BankVerificationRepo : RepoBase<BankVerificationsModel>, IBankVerificationRepo
    {
        private DefaultDbContext _context;

        public BankVerificationRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
            _context = databaseContext;
        }

        public void CheckBankValidationStatusByJobId(string jobId)
        {
            PvBerifyBankValidationRepo PbVerifyBankValidation = new PvBerifyBankValidationRepo();

            // get the bank validation object where jobId matches
            var bav = _context.BankVerifications.First(e => e.JobID == jobId);

            var bavStatus = PbVerifyBankValidation.GetBankValidationStatus(jobId);

            if (bavStatus.Status.ToLower() == "success")
            {
                var result = bavStatus.Results;
                bav.Reference = "Verification";
                //bav.AccountType = result.AccountType;
                //bav.VerificationType = result.VerificationType;
                bav.BranchCode = result.BranchCode;
                bav.AccountNumber = result.AccountNumber;
                bav.IdNumber = result.IdNumber;
                bav.Initials = result.Initials;
                bav.Surname = result.Surname;
                bav.FoundAtBank = result.FoundAtBank;
                bav.AccOpen = result.AccOpen;
                bav.OlderThan3Months = result.OlderThan3Months;
                bav.TypeCorrect = result.TypeCorrect;
                bav.IdNumberMatch = result.IdNumberMatch;
                bav.NamesMatch = result.SurnameMatch;
                bav.AcceptDebits = result.AcceptDebits;
                bav.AcceptCredits = result.AcceptCredits;

                _context.BankVerifications.Update(bav);

                // alse set the step entry as completed
                var step = _context.ApplicationSteps
                    .First(c => c.ApplicationId == bav.ApplicationId && c.StepType == ApplicationStepTypesEnum.BankValidation);
                step.Complete = true;
                _context.ApplicationSteps.Update(step);

                // set the application bank validation to complete
                var application = _context.Applications.Find(step.ApplicationId);
                application.BankValidationComplete = true;
                _context.Applications.Update(application);

                _context.SaveChanges();
            }
            else
                throw new Exception("Bank Validation Failed");
        }
    }
}