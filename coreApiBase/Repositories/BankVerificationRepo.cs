using alumaApi.Data;
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
                bav.Name = result.Name;
                bav.SearchData = result.SearchData;
                bav.Reference = result.Reference;
                bav.BankName = result.BankName;
                bav.AccountType = result.AccountType;
                bav.VerificationType = result.VerificationType;
                bav.BranchCode = result.BranchCode;
                bav.AccountNumber = result.AccountNumber;
                bav.AccountId = result.AccountId;
                bav.IdNumber = result.IdNumber;
                bav.Initials = result.Initials;
                bav.Surname = result.Surname;
                bav.FoundAtBank = result.FoundAtBank;
                bav.AccOpen = result.AccOpen;
                bav.OlderThan3Months = result.OlderThan3Months;
                bav.TypeCorrect = result.TypeCorrect;
                bav.IdNumberMatch = result.IdNumberMatch;
                bav.NamesMatch = result.NamesMatch;
                bav.AcceptDebits = result.AcceptDebits;
                bav.AcceptCredits = result.AcceptCredits;

                _context.BankVerifications.Update(bav);

                // alse set the step entry as completed
                var step = _context.ApplicationSteps.Find(bav.StepId);
                step.Complete = true;

                _context.ApplicationSteps.Update(step);
                _context.SaveChanges();
            }
            else
            {
                bav.ChecksCount += 1;
                // reque this job to check again in 15 minutes
                RequeStatusCheck(jobId, bav.ChecksCount);
            }
        }

        private void RequeStatusCheck(string jobId, int checksCount)
        {
            var interval = checksCount > 4 ? 60 : 15;
            // check again in the next interval period
            BackgroundJob.Schedule(() => CheckBankValidationStatusByJobId(jobId), TimeSpan.FromMinutes(interval));
        }
    }
}