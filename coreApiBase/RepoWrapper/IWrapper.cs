using MailSender;
using StringHasher;
using TokenProvider;
using BulkSms;
using JwtAuthentication;
using alumaApi.Repositories;
using KycFactory;
using alumaApi.Repositories.Shedules;

namespace alumaApi.RepoWrapper
{
    public interface IWrapper
    {
        IAdvisorAdvisedProductsRepo AdvisorAdvisedProducts { get; }
        IAdvisorAdviseRepo AdvisorAdvise { get; }
        IApplicationDocumentsRepo ApplicationDocuments { get; }
        IApplicationRepo Applications { get; }
        IApplicationStepRepo ApplicationSteps { get; }
        IBankVerificationRepo BankVerification { get; }
        IOtpRepo Otp { get; }
        IRiskProfileRepo RiskProfile { get; }
        IUserRepo User { get; }

        // Schedules
        IPrimaryIndividualRepo PrimaryIndividual { get; }

        // from other sources

        IBulkSmsRepo BulkSms { get; }
        IJwtRepo Jwt { get; }
        IKycFactoryRepo KycFactory { get; }
        IStringHasher StrHasher { get; }
        IMailSender SendMail { get; }
        ITokenProvider TokenProvider { get; }

        void Save();
    }
}