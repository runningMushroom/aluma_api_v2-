using alumaApi.Data;
using alumaApi.Enum;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IApplicationStepRepo : IRepoBase<ApplicationStepModel>
    {
        List<ApplicationStepModel> CreateApplicationSteps(string scheduleType, Guid applicationId);
    }

    public class ApplicationStepRepo : RepoBase<ApplicationStepModel>, IApplicationStepRepo
    {
        public ApplicationStepRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }

        public List<ApplicationStepModel> CreateApplicationSteps(string scheduleType, Guid applicationId)
        {
            var stepList = new List<ApplicationStepModel>();

            // 1:  Advisor Advice
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.AdvisorAdvice,
                ActiveStep = true,
                ApplicationId = applicationId,
                Order = 1,
            });

            // 2:  Digital KYC (This step can always be changed to a manual KYC)
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.DigitalKyc,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 2,
            });

            // 3:  Bank Validation
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.BankValidation,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 3,
            });

            // 4:  Primary Schedule
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.PrimarySchedule,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 4,
                ScheduleType =
                    scheduleType == "individual" ? ScheduleTypesEnum.Individual.ToString() :
                    scheduleType == "company" ? ScheduleTypesEnum.Company.ToString() : "Undefined Type"
            });

            // 5:  Record of advice
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.RecordOfAdvice,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 5,
            });

            // 6:  Record of advice
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.RiskProfile,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 6,
            });

            // 7:  FSP Mandate
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.FspMandate,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 7,
            });

            // 8:  Dividend
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.Dividens,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 8,
            });

            // 9:  Secondary Schedule
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.SecondarySchedule,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 9,
            });

            // 10:  Sign
            stepList.Add(new ApplicationStepModel()
            {
                StepType = ApplicationStepTypesEnum.Signature,
                ActiveStep = false,
                ApplicationId = applicationId,
                Order = 10,
            });

            return stepList;
        }
    }
}