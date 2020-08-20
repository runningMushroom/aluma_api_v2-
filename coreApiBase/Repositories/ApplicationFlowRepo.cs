//using alumaApi.Enum;
//using alumaApi.Models;
//using alumaApi.RepoWrapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace alumaApi.Repositories
//{
//    public interface IApplicationFlowRepo
//    {
//        bool AdvanceStep(Guid applicationId, ApplicationStepModel currentStep);
//    }

//    public class ApplicationFlowRepo : IApplicationFlowRepo
//    {
//        //private readonly IWrapper _repo;

//        //public ApplicationFlowRepo(IWrapper repo)
//        //{
//        //    _repo = repo;
//        //}

//        public bool AdvanceStep(Guid applicationId, ApplicationStepModel currentStep)
//        {
//            var result = false;

//            var application = _repo.Applications
//                .FindByCondition(c => c.Id == applicationId)
//                .First();

//            switch (currentStep.StepType)
//            {
//                case ApplicationStepTypesEnum.AdvisorAdvice:
//                    result = CompleteAdvisorAdvise(application, currentStep);
//                    break;

//                default:
//                    return false;
//            }

//            return result;
//        }

//        private bool CompleteAdvisorAdvise(ApplicationsModel application, ApplicationStepModel step)
//        {
//            // change step to complet & inactive
//            step.ActiveStep = false;
//            step.Complete = true;
//            _repo.ApplicationSteps.Update(step);

//            // get the next step in the list & make it active
//            var nextStep = application.Steps.Where(c => c.Order == (step.Order + 1)).First();
//            nextStep.ActiveStep = true;
//            _repo.ApplicationSteps.Update(nextStep);

//            return true;
//        }
//    }
//}