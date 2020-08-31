using MailSender;
using StringHasher;
using TokenProvider;
using alumaApi.Data;
using alumaApi.Repositories;
using BulkSms;

using JwtAuthentication;
using KycFactory;
using alumaApi.Repositories.Shedules;
using PbVerifyBankValidation;
using Microsoft.AspNetCore.Hosting;
using Signiflow;

namespace alumaApi.RepoWrapper
{
    public class Wrapper : IWrapper
    {
        private DefaultDbContext _dbContext;

        private IAdvisorAdvisedProductsRepo _advisorAdvisedProducts;
        private IAdvisorAdviseRepo _advisorAdvise;
        private IApplicationDocumentsRepo _applicationDocuments;
        private IApplicationRepo _application;
        private IApplicationStepRepo _applicationStep;
        private IBankVerificationRepo _bankVerification;
        private IDividendTaxRepo _dividendTax;
        private IFspMandateRepo _fspMandate;
        private IKycMetaDataRepo _kycMetaData;
        private IOtpRepo _otp;
        private IRecordOfAdviseRepo _recordOfAdvise;
        private IRequiredSecondarySchedulesRepo _requiredSecondarySchedules;
        private IRiskProfileRepo _riskProfile;
        private IUserRepo _user;

        // Schedules
        private IPrimaryIndividualRepo _primaryIndividual;

        private IBulkSmsRepo _bulkSMs;
        private IJwtRepo _jwt;
        private IKycFactoryRepo _kyc;
        private IMailSender _mailSender;
        private IPvBerifyBankValidationRepo _pbVerifyBankValidation;
        private ISigniflowRepo _signiflow;
        private IStringHasher _hasher;
        private ITokenProvider _tokenProvider;

        private readonly IWebHostEnvironment _host;

        public Wrapper(DefaultDbContext dbContext, IWebHostEnvironment host, ISigniflowRepo signiflow)
        {
            _dbContext = dbContext;
            _host = host;
            _signiflow = signiflow;
        }

        public IAdvisorAdvisedProductsRepo AdvisorAdvisedProducts
        {
            get { return _advisorAdvisedProducts == null ? new AdvisorAdvisedProductsRepo(_dbContext) : _advisorAdvisedProducts; }
        }

        public IAdvisorAdviseRepo AdvisorAdvise
        {
            get { return _advisorAdvise == null ? new AdvisorAdviseRepo(_dbContext) : _advisorAdvise; }
        }

        public IApplicationDocumentsRepo ApplicationDocuments
        {
            get { return _applicationDocuments == null ? new ApplicationDocumentsRepo(_dbContext) : _applicationDocuments; }
        }

        public IApplicationRepo Applications
        {
            get { return _application == null ? new ApplicationRepo(_dbContext, _host, _signiflow) : _application; }
        }

        public IApplicationStepRepo ApplicationSteps
        {
            get { return _applicationStep == null ? new ApplicationStepRepo(_dbContext) : _applicationStep; }
        }

        public IBankVerificationRepo BankVerification
        {
            get { return _bankVerification == null ? new BankVerificationRepo(_dbContext) : _bankVerification; }
        }

        public IDividendTaxRepo DividendTax
        {
            get { return _dividendTax == null ? new DividendTaxRepo(_dbContext) : _dividendTax; }
        }

        public IFspMandateRepo FspMandate
        {
            get { return _fspMandate == null ? new FspMandateRepo(_dbContext) : _fspMandate; }
        }

        public IKycMetaDataRepo KycMetaData
        {
            get { return _kycMetaData == null ? new KycMetaDataRepo(_dbContext) : _kycMetaData; }
        }

        public IOtpRepo Otp
        {
            get { return _otp == null ? new OtpRepo(_dbContext) : _otp; }
        }

        public IRecordOfAdviseRepo RecordOfAdvise
        {
            get { return _recordOfAdvise == null ? new RecordOfAdviseRepo(_dbContext) : _recordOfAdvise; }
        }

        public IRequiredSecondarySchedulesRepo RequiredSecondarySchedules
        {
            get { return _requiredSecondarySchedules == null ? new RequiredSecondarySchedulesRepo(_dbContext) : _requiredSecondarySchedules; }
        }

        public IRiskProfileRepo RiskProfile
        {
            get { return _riskProfile == null ? new RiskProfileRepo(_dbContext) : _riskProfile; }
        }

        public IUserRepo User
        {
            get { return _user == null ? new UserRepo(_dbContext) : _user; }
        }

        // Primary Schedules

        public IPrimaryIndividualRepo PrimaryIndividual
        {
            get { return _primaryIndividual == null ? new PrimaryIndividualRepo(_dbContext) : _primaryIndividual; }
        }

        // non db
        public IBulkSmsRepo BulkSms
        {
            get { return _bulkSMs == null ? new BulkSmsRepo() : _bulkSMs; }
        }

        public IJwtRepo Jwt
        {
            get { return _jwt == null ? new JwtRepo() : _jwt; }
        }

        public IKycFactoryRepo KycFactory
        {
            get { return _kyc == null ? new KycFactoryRepo() : _kyc; }
        }

        public IMailSender SendMail
        {
            get { return _mailSender == null ? new MailSenderRepo() : _mailSender; }
        }

        public IPvBerifyBankValidationRepo PbVerifyBankValidation
        {
            get { return _pbVerifyBankValidation == null ? new PvBerifyBankValidationRepo() : _pbVerifyBankValidation; }
        }

        public ISigniflowRepo Signiflow
        {
            get { return _signiflow == null ? new SigniflowRepo() : _signiflow; }
        }

        public IStringHasher StrHasher
        {
            get { return _hasher == null ? new StringHasherRepo() : _hasher; }
        }

        public ITokenProvider TokenProvider
        {
            get { return _tokenProvider == null ? new TokenProviderRepo() : _tokenProvider; }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}