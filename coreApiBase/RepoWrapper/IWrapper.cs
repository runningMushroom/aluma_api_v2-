using MailSender;
using StringHasher;
using TokenProvider;
using BulkSms;
using JwtAuthentication;
using alumaApi.Repositories;
using KycFactory;
using alumaApi.Repositories.Shedules;
using PbVerifyBankValidation;

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
        IDividendTaxRepo DividendTax { get; }
        IFspMandateRepo FspMandate { get; }
        IKycMetaDataRepo KycMetaData { get; }
        IOtpRepo Otp { get; }
        IRecordOfAdviseRepo RecordOfAdvise { get; }
        IRequiredSecondarySchedulesRepo RequiredSecondarySchedules { get; }
        IRiskProfileRepo RiskProfile { get; }
        IUserRepo User { get; }

        // Schedules
        IPrimaryIndividualRepo PrimaryIndividual { get; }

        // from other sources

        IBulkSmsRepo BulkSms { get; }
        IJwtRepo Jwt { get; }
        IKycFactoryRepo KycFactory { get; }
        IMailSender SendMail { get; }
        IPvBerifyBankValidationRepo PbVerifyBankValidation { get; }
        IStringHasher StrHasher { get; }
        ITokenProvider TokenProvider { get; }

        void Save();
    }
}