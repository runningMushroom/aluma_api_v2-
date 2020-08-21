using MailSender;
using StringHasher;
using TokenProvider;
using BulkSms;
using JwtAuthentication;
using alumaApi.Repositories;
using KycFactory;

namespace alumaApi.RepoWrapper
{
    public interface IWrapper
    {
        IAdvisorAdvisedProductsRepo AdvisorAdvisedProducts { get; }
        IAdvisorAdviseRepo AdvisorAdvise { get; }
        IApplicationRepo Applications { get; }
        IApplicationStepRepo ApplicationSteps { get; }
        IOtpRepo Otp { get; }
        IUserRepo User { get; }

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